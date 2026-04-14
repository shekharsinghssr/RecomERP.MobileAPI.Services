using System.Data;

namespace RecomERP.MobileAPI.Infrastructure.Services
{
    public class SqlParameterBuilder
    {
        private readonly Dictionary<string, (SqlDbType Type, object Value)> _parameters = new(StringComparer.OrdinalIgnoreCase);

        public static SqlParameterBuilder Create() => new();


        /// <summary>
        /// Adds a SQL parameter to the builder using the specified name, SQL data type,
        /// and value. Null values are automatically converted to <see cref="DBNull"/> 
        /// to ensure compatibility with ADO.NET command execution.
        /// </summary>
        /// <param name="name">The name of the SQL parameter.</param>
        /// <param name="type">The <see cref="SqlDbType"/> associated with the parameter.</param>
        /// <param name="value">The value assigned to the parameter. May be null.</param>
        /// <returns>
        /// The current <see cref="SqlParameterBuilder"/> instance, enabling fluent chaining.
        /// </returns>
        public SqlParameterBuilder Add(string name, SqlDbType type, object? value)
        {
            _parameters[name] = (type, value ?? DBNull.Value);
            return this;
        }

        /// <summary>
        /// Adds a SQL parameter of type <see cref="SqlDbType.VarChar"/> to the builder.
        /// Automatically converts null values to <see cref="DBNull"/>.
        /// </summary>
        /// <param name="name">The name of the SQL parameter.</param>
        /// <param name="value">The string value to assign to the parameter.</param>
        /// <returns>The current <see cref="SqlParameterBuilder"/> instance for fluent chaining.</returns>
        public SqlParameterBuilder AddString(string name, string? value) => Add(name, SqlDbType.VarChar, value);

        /// <summary>
        /// Adds a SQL parameter of type <see cref="SqlDbType.Int"/> to the builder.
        /// Automatically converts null values to <see cref="DBNull"/>.
        /// </summary>
        /// <param name="name">The name of the SQL parameter.</param>
        /// <param name="value">The integer value to assign to the parameter.</param>
        /// <returns>The current <see cref="SqlParameterBuilder"/> instance for fluent chaining.</returns>
        public SqlParameterBuilder AddInt(string name, int? value) => Add(name, SqlDbType.Int, value);

        /// <summary>
        /// Adds a SQL parameter of type <see cref="SqlDbType.DateTime"/> to the builder.
        /// Automatically converts null values to <see cref="DBNull"/>.
        /// </summary>
        /// <param name="name">The name of the SQL parameter.</param>
        /// <param name="value">The date value to assign to the parameter.</param>
        /// <returns>The current <see cref="SqlParameterBuilder"/> instance for fluent chaining.</returns>
        public SqlParameterBuilder AddDate(string name, DateTime? value) => Add(name, SqlDbType.DateTime, value);

        /// <summary>
        /// Finalizes the parameter collection and returns all configured SQL parameters.
        /// Converts the internal builder state into a dictionary where each entry contains
        /// the parameter name, its <see cref="SqlDbType"/>, and the resolved value
        /// (with nulls already converted to <see cref="DBNull"/>).
        /// </summary>
        /// <returns>
        /// A dictionary of SQL parameters keyed by parameter name, each containing the
        /// associated SQL type and value.
        /// </returns>
        public Dictionary<string, (SqlDbType Type, object Value)> Build() => _parameters;
    }
}
