using Microsoft.Data.SqlClient;

namespace PrashantApi.Application.Interfaces.Logging
{
    public interface ILog
    {
        void LogException(Exception ex, string module = null);
        void LogInfo(string message);
        void LogDetailedException(SqlException ex, string module = null);
        void LogUIException(string exceptionMessage, string module = null);
    }
}
