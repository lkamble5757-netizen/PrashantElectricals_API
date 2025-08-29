using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace PrashantApi.Infrastructure.Data
{
    public interface ISqlServerDataAccess
    {
        Task<int> ExecuteNonQuery(string command, DynamicParameters dynamicParameters, CommandType commandType = CommandType.StoredProcedure);
        Task ExecuteAsync(string command, DynamicParameters dynamicParameters, CommandType commandType = CommandType.StoredProcedure);
        Task ExecuteAsync(string command, object dynamicParameters, CommandType commandType = CommandType.StoredProcedure);
        Task<dynamic> QueryAsync(CommandDefinition commandDefinition);
        Task<dynamic> QueryAsync(string commandText, object parameteres, CommandType commandType);
        Task<dynamic> QueryAsync(string commandText, CommandType commandType);
        Task<GridReader> QueryMultipleAsync(string commandText, object parameteres, CommandType commandType);   
        Task<GridReader> QueryMultipleAsync(CommandDefinition commandDefinition);
        Task<dynamic> QueryMultiple(string commandText, object parameteres, CommandType commandType, IEnumerable<MapItem> mapItems = null);
        Task<dynamic> QueryMultiple(CommandDefinition commandDefinition);
        Task<dynamic> ExecuteScalarAsync(string command, object dynamicParameters, CommandType commandType = CommandType.StoredProcedure);
        SqlConnection GetSqlConnection();
    }
}
