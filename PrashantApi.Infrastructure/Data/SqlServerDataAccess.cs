using Dapper;
using Microsoft.Data.SqlClient;
using PrashantApi.Infrastructure.Connection;
using PrashantApi.Infrastructure.Logger;
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace PrashantApi.Infrastructure.Data
{
    public class SqlServerDataAccess : ISqlServerDataAccess
    {
        private readonly ISqlDbConnection sqlDbConnection;
        private readonly ILoggerWrapper logger; 

        public SqlServerDataAccess(ISqlDbConnection sqlDbConnection,
            ILoggerWrapper logger)
        {
            this.sqlDbConnection = sqlDbConnection;
            this.logger = logger;
        }

        public async Task ExecuteAsync(string command, DynamicParameters dynamicParameters, CommandType commandType = CommandType.StoredProcedure)
        {
            using var connection = sqlDbConnection.GetConnection();

            try
            {
                await connection.ExecuteAsync(command, dynamicParameters, commandType: commandType);
            }

            catch (Exception ex)
            {
                logger.Fatal(ex, ex.Message);
                throw;
            }
        }

        public async Task ExecuteAsync(string command, object dynamicParameters, CommandType commandType = CommandType.StoredProcedure)
        {
            using var connection = sqlDbConnection.GetConnection();

            try
            {
                await connection.ExecuteAsync(command, dynamicParameters, commandType: commandType);
            }

            catch (Exception ex)
            {
                logger.Fatal(ex, ex.Message);
                throw;
            }
        }

        public async Task<int> ExecuteNonQuery(string command, DynamicParameters dynamicParameters, CommandType commandType = CommandType.StoredProcedure)
        {
            using var connection = sqlDbConnection.GetConnection();

            //
            try
            {
                await connection.ExecuteAsync(command, dynamicParameters, commandType: commandType);
                //
                return 1;
            }

            catch (Exception ex)
            {
                logger.Fatal(ex, ex.Message);
                //
                throw;
            }
        }

        public async Task<dynamic> ExecuteScalarAsync(string command, object dynamicParameters, CommandType commandType = CommandType.StoredProcedure)
        {
            using var connection = sqlDbConnection.GetConnection();
            return await connection.ExecuteScalarAsync<dynamic>(command, dynamicParameters, commandType: CommandType.StoredProcedure);
        }

        public SqlConnection GetSqlConnection()
        {
            return sqlDbConnection.GetConnection();
        }

        public async Task<dynamic> QueryAsync(CommandDefinition commandDefinition)
        {
            using var connection = sqlDbConnection.GetConnection();
            return await connection.QueryAsync<dynamic>(commandDefinition);
        }

        public async Task<dynamic> QueryAsync(string commandText, object parameteres, CommandType commandType)
        {
            using var connection = sqlDbConnection.GetConnection();
            return await connection.QueryAsync<dynamic>(commandText, parameteres, commandType: commandType);
        }

        public async Task<dynamic> QueryAsync(string commandText, CommandType commandType)
        {
            using var connection = sqlDbConnection.GetConnection();
            return await connection.QueryAsync<dynamic>(commandText, commandType: commandType);
        }

        public async Task<dynamic> QueryMultiple(string commandText, object parameteres, CommandType commandType, IEnumerable<MapItem> mapItems = null)
        {
            var data = new ExpandoObject();
            using (var connection = sqlDbConnection.GetConnection())
            {
                var gridReader = await connection.QueryMultipleAsync(commandText, parameteres, commandType: commandType);


                if (mapItems == null) return gridReader;

                foreach (var item in mapItems)
                {
                    if (item.DataRetriveType == DataRetriveTypeEnum.FirstOrDefault && !gridReader.IsConsumed)
                    {
                        var singleItem = gridReader.ReadFirstOrDefault(item.Type);
                        ((IDictionary<string, object>)data).Add(item.Key, singleItem);
                        continue;
                    }

                    if (item.DataRetriveType == DataRetriveTypeEnum.List && !gridReader.IsConsumed)
                    {
                        var listItem = gridReader.Read(item.Type).ToList();
                        ((IDictionary<string, object>)data).Add(item.Key, listItem);
                    }
                }

                //while (!gridReader.IsConsumed)
                //{
                //    counter++;
                //    result.Add(counter, gridReader.ReadFirstOrDefault());
                //}
                return data;
            }
        }

        public async Task<dynamic> QueryMultiple(CommandDefinition commandDefinition)
        {
            var result = new Dictionary<short, dynamic>();
            using (var connection = sqlDbConnection.GetConnection())
            {
                var gridReader = connection.QueryMultipleAsync(commandDefinition).Result;
                short counter = 0;

                while (!gridReader.IsConsumed)
                {
                    counter++;
                    result.Add(counter, gridReader.ReadFirstOrDefault());
                }
                return result;
            }
        }

        public Tuple<IEnumerable<T1>, IEnumerable<T2>> QueryMultipleAsync<T1, T2>(string commandText, object parameteres, CommandType commandType, Func<GridReader, IEnumerable<T1>> func1, Func<GridReader, IEnumerable<T2>> func2)
        {
            var objs = GetMultiple(commandText, parameteres, func1, func2);
            return Tuple.Create(objs[0] as IEnumerable<T1>, objs[1] as IEnumerable<T2>);
        }
        private List<object> GetMultiple(string sql, object parameters, params Func<GridReader, object>[] readerFuncs)
        {
            var returnResults = new List<object>();
            using (var connection = sqlDbConnection.GetConnection())
            {
                var gridReader = connection.QueryMultiple(sql, parameters);

                foreach (var readerFunc in readerFuncs)
                {
                    var obj = readerFunc(gridReader);
                    returnResults.Add(obj);
                }
            }

            return returnResults;
        }

        Task<GridReader> ISqlServerDataAccess.QueryMultipleAsync(string commandText, object parameters, CommandType commandType)
        {
            throw new NotImplementedException();
        }


        Task<GridReader> ISqlServerDataAccess.QueryMultipleAsync(CommandDefinition commandDefinition)
        {
            throw new NotImplementedException();
        }
    }
}
