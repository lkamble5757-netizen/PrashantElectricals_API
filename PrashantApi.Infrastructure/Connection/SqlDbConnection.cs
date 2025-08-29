using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using PrashantEle.API.PrashantEle.Infrastructure.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrashantApi.Infrastructure.Connection
{
    public class SqlDbConnection : ISqlDbConnection
    {
        private readonly string connectionString;

        public SqlDbConnection(IConfiguration configuration)
        { 
            connectionString = configuration.GetConnectionString("PrashantConnectionString");
        }
        public SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
