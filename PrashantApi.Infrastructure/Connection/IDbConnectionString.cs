using Microsoft.Data.SqlClient;

namespace PrashantApi.Infrastructure.Connection
{
    public interface IDbConnectionString
    {
        SqlConnection GetConnection();
        //SqlConnection GetEvaluationConnection();
    }
}
