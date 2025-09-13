using Microsoft.Data.SqlClient;

namespace PrashantEle.API.PrashantEle.Infrastructure.Connection
{
    public interface IDbConnectionString
    {
        SqlConnection GetConnection();
        //SqlConnection GetEvaluationConnection();
    }
}
