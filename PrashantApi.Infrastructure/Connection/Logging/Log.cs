using Dapper;
using Microsoft.Data.SqlClient;
using PrashantApi.Application.Interfaces.Logging;
using PrashantEle.API.PrashantEle.Infrastructure.Connection;
using System.Collections;
using System.Data;
using System.Text;

namespace PrashantEle.API.PrashantEle.Domain.Logging
{
    public class Log : ILog
    {
        private readonly IDbConnectionString _dbConnectionString;
        public Log(IDbConnectionString dbConnectionString)
        {
            _dbConnectionString = dbConnectionString;
        }
        public void LogException(Exception ex, string module = null)
        {
            LogExceptionToDb($"PrashantEle Error Code: 201: Message: {ex.Message} {Environment.NewLine} InnerException: {ex.InnerException} {Environment.NewLine} Stack Trace {ex.StackTrace}");
        }

        public void LogInfo(string message)
        {
            LogExceptionToDb($"User IP Address: {message}");
        }
        public void LogDetailedException(SqlException ex, string module = null)
        {
            StringBuilder sb = new StringBuilder();
            if (ex.Data != null && ex.Data.Keys.Count > 0)
            {
                foreach (DictionaryEntry param in ex.Data)
                {
                    if (Convert.ToString(param.Key) != "HelpLink.ProdName" && Convert.ToString(param.Key) != "HelpLink.ProdVer" && Convert.ToString(param.Key) != "HelpLink.EvtSrc"
                        && Convert.ToString(param.Key) != "HelpLink.EvtID" && Convert.ToString(param.Key) != "HelpLink.BaseHelpUrl" && Convert.ToString(param.Key) != "HelpLink.LinkId")
                    {
                        sb.Append($"{param.Key} = {param.Value} {Environment.NewLine}");
                    }
                }
            }
            LogUIException($"PrashantEle Error Code: 101: Message: {ex.Message} {Environment.NewLine} InnerException: {ex.InnerException} {Environment.NewLine} Stack Trace {ex.StackTrace} {Environment.NewLine} Parameters {sb.ToString()}");
        }
        public void LogUIException(string exceptionMessage, string module = null)
        {
            LogExceptionToDb($"PrashantEle Error Code: 301: Message: {exceptionMessage}");
        }

        public void LogExceptionToDb(string errorMessage)
        {
            using (var connection = _dbConnectionString.GetConnection())
            {
                connection.ExecuteAsync("usp_SaveErrorLogInfo", new { ErrorMessage = errorMessage }, commandType: CommandType.StoredProcedure);
            }
        }

    }
}
