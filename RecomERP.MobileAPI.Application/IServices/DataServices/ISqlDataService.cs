using Microsoft.Data.SqlClient;
using RecomERP.MobileAPI.Common.Enums;
using System.Data;

namespace RecomERP.MobileAPI.Application.IServices.DataServices
{
    public interface ISqlDataService
    {
        Dictionary<string, (SqlDbType, object)> CreateSqlParameters(params (string Name, SqlDbType Type, object Value)[] entries);
        int ExecuteNonQuery(string sql, SqlParameter[] parameters = null, ConnectionType connectionType = ConnectionType.RecomERPCore);
        T ExecuteScalar<T>(string sql, SqlParameter[] parameters = null, ConnectionType connectionType = ConnectionType.RecomERPCore);
        Task<int> ExecuteStoredProcedureAsync(string procedureName, Dictionary<string, (SqlDbType Type, object Value)> parameters, ConnectionType connectionType = ConnectionType.RecomERPCore);
        Task<DataTable> ExecuteDataTableAsync(string procedureName, Dictionary<string, (SqlDbType, object)> parameters = null, ConnectionType connectionType = ConnectionType.RecomERPCore, CancellationToken cancellationToken = default);
        Task<DataSet> ExecuteDataSetAsync(string procedureName, SqlParameter[] parameters = null, ConnectionType connectionType = ConnectionType.RecomERPCore, CancellationToken cancellationToken = default);
        Task<IEnumerable<T>> QueryStoredProcedureAsync<T>(
            string procedureName,
            Dictionary<string, (SqlDbType Type, object Value)> parameters = null,
            ConnectionType connectionType = ConnectionType.RecomERPCore,
            CancellationToken cancellationToken = default
        ) where T : new();
    }
}
