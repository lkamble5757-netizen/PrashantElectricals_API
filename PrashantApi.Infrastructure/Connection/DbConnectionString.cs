using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace PrashantApi.Infrastructure.Connection
{
    public class DbConnectionString(IConfiguration config) : IDbConnectionString
    {
        private readonly string _prashantConn = config.GetConnectionString("PrashantConnectionString");
        private readonly string _evaluationConn;

        public SqlConnection GetConnection()
        {
            // _prashantConn already holds the full connection string
            return BuildConnection(_prashantConn);
        }

        //public SqlConnection GetEvaluationConnection()
        //{
        //    return BuildConnection(_evaluationConn);
        //}

        private static SqlConnection BuildConnection(string connString)
        {
            return new SqlConnection(connString);
        }
    }
}
