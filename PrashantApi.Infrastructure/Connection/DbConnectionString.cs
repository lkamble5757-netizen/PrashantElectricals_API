using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace PrashantEle.API.PrashantEle.Infrastructure.Connection
{
    public class DbConnectionString : IDbConnectionString
    {
        private readonly string _prashantConn;
        private readonly string _evaluationConn;

        public DbConnectionString(IConfiguration config)
        {
            _prashantConn = config.GetConnectionString("PrashantConnectionString");
            //_evaluationConn = config.GetConnectionString("evaluationConnectionString");
        }

        public SqlConnection GetConnection()
        {
            // _prashantConn already holds the full connection string
            return BuildConnection(_prashantConn);
        }

        //public SqlConnection GetEvaluationConnection()
        //{
        //    return BuildConnection(_evaluationConn);
        //}

        private SqlConnection BuildConnection(string connString)
        {
            return new SqlConnection(connString);
        }
    }
}
