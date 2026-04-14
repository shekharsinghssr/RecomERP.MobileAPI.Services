using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

using RecomERP.MobileAPI.Application.IServices.DataServices;
using RecomERP.MobileAPI.Common.Enums;
using RecomERP.MobileAPI.Infrastructure.Services;
using System.Data;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace RecomERP.API.Infrastructure.Services
{
    public class SqlDataService : ISqlDataService
    {
        //private readonly string _connectionString;
        private readonly IConfiguration _configuration;
        private readonly Dictionary<ConnectionType, string> _connectionStrings = new();

        /// <summary>
        /// Initializes a new instance of the SqlDataService class.
        /// </summary>
        /// <param name="configuration"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public SqlDataService(IConfiguration configuration)
        {
            if (configuration == null)
                throw new ArgumentNullException(nameof(configuration));
            try
            {
                _configuration = configuration;

                _connectionStrings = new Dictionary<ConnectionType, string>
                {
                    { ConnectionType.RecomERPCore, _configuration.GetConnectionString("RecomERPDb") ?? string.Empty },
                    { ConnectionType.ClientDB,     _configuration.GetConnectionString("SPDClientDb") ?? string.Empty },
                    { ConnectionType.MasterDB,     _configuration.GetConnectionString("SPDMasterDb") ?? string.Empty },

                };

                foreach (var kvp in _connectionStrings)
                {
                    if (string.IsNullOrWhiteSpace(kvp.Value))
                        throw new ArgumentException($"Connection string for {kvp.Key} is not configured properly.");
                }
            }
            catch (Exception ex)
            {
                // Optional: log here if you inject ILogger<SqlDataService>
                // _logger.LogError(ex, "Failed to initialize SqlDataService.");
                throw new InvalidOperationException("Failed to initialize SqlDataService due to invalid configuration.", ex);
            }
        }

        /// <summary>
        /// Retrieves the connection string based on the specified ConnectionType.
        /// </summary>
        /// <param name="connectionType"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        private string GetConnectionString(ConnectionType connectionType)
        {
            try
            {
                if (_connectionStrings.TryGetValue(connectionType, out var connectionString))
                    return connectionString;
                throw new ArgumentException($"Connection string for {connectionType} not found.");
            }
            catch (Exception ex)
            {
                // Optional: log the error if ILogger is injected
                // _logger.LogError(ex, "Failed to retrieve connection string for {ConnectionType}", connectionType);
                throw new InvalidOperationException($"Error retrieving connection string for {connectionType}.", ex);
            }
        }

        /// <summary>
        /// Creates a dictionary of SQL parameters from the provided entries.
        /// </summary>
        /// <param name="entries"></param>
        /// <returns></returns>
        public Dictionary<string, (SqlDbType, object)> CreateSqlParameters(params (string Name, SqlDbType Type, object Value)[] entries)
        {
            try
            {
                var parameters = new Dictionary<string, (SqlDbType, object)>();
                foreach (var entry in entries)
                {
                    if (string.IsNullOrWhiteSpace(entry.Name))
                        throw new ArgumentException("Parameter name cannot be null or empty.");
                    parameters[entry.Name] = (entry.Type, entry.Value ?? DBNull.Value);
                }
                return parameters;
            }
            catch (Exception ex)
            {
                // Optional: log here if ILogger is injected
                // _logger.LogError(ex, "Failed to create SQL parameters.");
                throw new InvalidOperationException("An error occurred while creating SQL parameters.", ex);
            }
        }

        /// <summary>
        /// Converts a dictionary of parameter definitions to an array of SqlParameter objects.
        /// </summary>
        /// <param name="parameterMap"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public static SqlParameter[] ToSqlParameters(Dictionary<string, (SqlDbType Type, object Value)> parameterMap)
        {
            if (parameterMap == null)
                throw new ArgumentNullException(nameof(parameterMap));
            try
            {
                return parameterMap.Select(kvp =>
                {
                    if (string.IsNullOrWhiteSpace(kvp.Key))
                        throw new ArgumentException("SQL parameter name cannot be null or empty.");

                    var param = new SqlParameter(kvp.Key, kvp.Value.Type)
                    {
                        Value = kvp.Value.Value ?? DBNull.Value
                    };
                    return param;
                }).ToArray();
            }
            catch (Exception ex)
            {
                // Optional: integrate ILogger for structured logging
                // _logger.LogError(ex, "Failed to convert parameter map to SqlParameter[]");
                throw new InvalidOperationException("An error occurred while converting the parameter map to SQL parameters.", ex);
            }
        }

        /// <summary>
        /// Executes a stored procedure with parameters and returns the number of affected rows.
        /// </summary>
        /// <param name="procedureName"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task<int> ExecuteStoredProcedureAsync(string procedureName, Dictionary<string, (SqlDbType Type, object Value)> parameters, ConnectionType connectionType = ConnectionType.RecomERPCore)
        {
            if (string.IsNullOrWhiteSpace(procedureName))
                throw new ArgumentException("Stored procedure name cannot be null or empty.", nameof(procedureName));

            if (parameters == null)
                throw new ArgumentNullException(nameof(parameters));
            try
            {
                await using var connection = new SqlConnection(GetConnectionString(connectionType));
                await using var command = new SqlCommand(procedureName, connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                foreach (var param in parameters)
                {
                    if (string.IsNullOrWhiteSpace(param.Key))
                        throw new ArgumentException("SQL parameter name cannot be null or empty.");

                    // OUTPUT / custom SqlParameter
                    if (param.Value.Value is SqlParameter sqlParam)
                    {
                        command.Parameters.Add(sqlParam);
                    }
                    else
                    {
                        // Normal input parameter
                        command.Parameters.Add(param.Key, param.Value.Type)
                                          .Value = param.Value.Value ?? DBNull.Value;
                    }
                }
                await connection.OpenAsync();
                return await command.ExecuteNonQueryAsync();
            }
            catch (SqlException sqlEx)
            {
                // Preserve DB error message
                throw new Exception(sqlEx.Message, sqlEx);
            }
            catch (Exception ex)
            {
                // Optional: integrate ILogger for structured logging
                // _logger.LogError(ex, "Failed executing stored procedure {ProcedureName}", procedureName);
                throw new InvalidOperationException($"Error executing stored procedure '{procedureName}'.", ex);
            }
        }

        /// <summary>
        /// Executes a SQL query asynchronously and returns the result as a DataTable.
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<DataTable> ExecuteDataTableAsync(string procedureName,
                                                           Dictionary<string, (SqlDbType, object)> parameters = null,
                                                           ConnectionType connectionType = ConnectionType.RecomERPCore,
                                                           CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(procedureName))
                throw new ArgumentException("Stored procedure name cannot be null or empty.", nameof(procedureName));

            try
            {
                await using var connection = new SqlConnection(GetConnectionString(connectionType));
                await using var command = new SqlCommand(procedureName, connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                if (parameters != null)
                {
                    var sqlParams = SqlDataService.ToSqlParameters(parameters);
                    command.Parameters.AddRange(sqlParams);
                }

                using var adapter = new SqlDataAdapter(command);
                var result = new DataTable();

                await connection.OpenAsync(cancellationToken).ConfigureAwait(false);
                adapter.Fill(result); // synchronous
                return result;
            }

            catch (SqlException sqlEx)
            {
                // Preserve DB error message
                throw new Exception(sqlEx.Message, sqlEx);
            }
            catch (Exception ex)
            {
                throw new Exception($"Unexpected error while executing '{procedureName}'", ex);
            }
        }

        /// <summary>
        /// Executes a SQL query asynchronously and returns the result as a DataSet.
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<DataSet> ExecuteDataSetAsync(string procedureName,
                                                        SqlParameter[] parameters = null,
                                                        CancellationToken cancellationToken = default,
                                                        ConnectionType connectionType = ConnectionType.RecomERPCore)
        {
            if (string.IsNullOrWhiteSpace(procedureName))
                throw new ArgumentException("Stored procedure name cannot be null or empty.", nameof(procedureName));

            try
            {
                await using var connection = new SqlConnection(GetConnectionString(connectionType));
                await using var command = new SqlCommand(procedureName, connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                if (parameters != null)
                    command.Parameters.AddRange(parameters);

                using var adapter = new SqlDataAdapter(command);
                var result = new DataSet();

                await connection.OpenAsync(cancellationToken).ConfigureAwait(false);
                adapter.Fill(result); // synchronous
                return result;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error executing stored procedure '{procedureName}' for DataSet.", ex);
            }
        }



        /// <summary>
        /// Executes a SQL non-query command (INSERT, UPDATE, DELETE) and returns the number of affected rows.
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public int ExecuteNonQuery(string sql, SqlParameter[] parameters = null, ConnectionType connectionType = ConnectionType.RecomERPCore)
        {
            if (string.IsNullOrWhiteSpace(sql))
                throw new ArgumentException("SQL command cannot be null or empty.", nameof(sql));
            try
            {
                using var connection = new SqlConnection(GetConnectionString(connectionType));
                using var command = new SqlCommand(sql, connection);

                if (parameters != null)
                    command.Parameters.AddRange(parameters);

                connection.Open();
                return command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error executing SQL non-query command: {sql}", ex);
            }
        }

        /// <summary>
        /// Executes a SQL scalar command and returns the result cast to the specified type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public T ExecuteScalar<T>(string sql, SqlParameter[] parameters = null, ConnectionType connectionType = ConnectionType.RecomERPCore)
        {
            if (string.IsNullOrWhiteSpace(sql))
                throw new ArgumentException("SQL command cannot be null or empty.", nameof(sql));

            try
            {
                using var connection = new SqlConnection(GetConnectionString(connectionType));
                using var command = new SqlCommand(sql, connection);
                if (parameters != null)
                    command.Parameters.AddRange(parameters);
                connection.Open();
                object result = command.ExecuteScalar();

                return result != null && result != DBNull.Value ? (T)Convert.ChangeType(result, typeof(T)) : default;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error executing SQL scalar command: {sql}", ex);
            }
        }

        public Task<DataSet> ExecuteDataSetAsync(string procedureName, SqlParameter[] parameters = null, ConnectionType connectionType = ConnectionType.RecomERPCore, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<DataSet> ExecuteDataSetAsync(string procedureName,
                                               Dictionary<string, (SqlDbType, object)> parameters = null,
                                               ConnectionType connectionType = ConnectionType.RecomERPCore,
                                               CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(procedureName))
                throw new ArgumentException("Stored procedure name cannot be null or empty.", nameof(procedureName));

            try
            {
                await using var connection = new SqlConnection(GetConnectionString(connectionType));
                await using var command = new SqlCommand(procedureName, connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                if (parameters != null)
                {
                    var sqlParams = SqlDataService.ToSqlParameters(parameters);
                    command.Parameters.AddRange(sqlParams);
                }

                using var adapter = new SqlDataAdapter(command);
                var result = new DataSet();

                await connection.OpenAsync(cancellationToken).ConfigureAwait(false);
                adapter.Fill(result); // synchronous fill, but works fine with async open

                return result;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error executing stored procedure '{procedureName}' for DataSet.", ex);
            }
        }


        private void LogExecutionTime(string method, TimeSpan duration)
        {
            // Replace with your logging framework
            Console.WriteLine($"[{method}] executed in {duration.TotalMilliseconds} ms");
        }

        /// <summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="procedureName"></param>
        /// <param name="parameters"></param>
        /// <param name="connectionType"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public async Task<IEnumerable<T>> QueryStoredProcedureAsync<T>(
            string procedureName,
            Dictionary<string, (SqlDbType Type, object Value)> parameters = null,
            ConnectionType connectionType = ConnectionType.RecomERPCore,
            CancellationToken cancellationToken = default
        ) where T : new()
        {
            if (string.IsNullOrWhiteSpace(procedureName))
                throw new ArgumentException("Stored procedure name cannot be null or empty.", nameof(procedureName));

            var results = new List<T>();

            try
            {
                await using var connection = new SqlConnection(GetConnectionString(connectionType));
                await using var command = new SqlCommand(procedureName, connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                if (parameters != null)
                {
                    var sqlParams = ToSqlParameters(parameters);
                    command.Parameters.AddRange(sqlParams);
                }

                await connection.OpenAsync(cancellationToken).ConfigureAwait(false);

                await using var reader = await command.ExecuteReaderAsync(cancellationToken);

                var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

                while (await reader.ReadAsync(cancellationToken))
                {
                    var obj = new T();

                    foreach (var prop in properties)
                    {
                        if (!reader.HasColumn(prop.Name))
                            continue;

                        var value = reader[prop.Name];

                        if (value == DBNull.Value)
                            continue;

                        var targetType = Nullable.GetUnderlyingType(prop.PropertyType)
                                         ?? prop.PropertyType;

                        if (targetType == typeof(decimal))
                            prop.SetValue(obj, Convert.ToDecimal(value));
                        else if (targetType == typeof(int))
                            prop.SetValue(obj, Convert.ToInt32(value));
                        else if (targetType == typeof(long))
                            prop.SetValue(obj, Convert.ToInt64(value));
                        else if (targetType == typeof(bool))
                            prop.SetValue(obj, Convert.ToBoolean(value));
                        else if (targetType == typeof(DateTime))
                            prop.SetValue(obj, Convert.ToDateTime(value));
                        else if (targetType.IsEnum)
                            prop.SetValue(obj, Enum.ToObject(targetType, value));
                        else
                            prop.SetValue(obj, Convert.ChangeType(value, targetType));
                    }

                    results.Add(obj);
                }

                return results;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(
                    $"Error executing stored procedure '{procedureName}' and mapping to {typeof(T).Name}.",
                    ex
                );
            }
        }



    }
}
