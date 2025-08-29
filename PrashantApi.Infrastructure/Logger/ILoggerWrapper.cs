using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrashantApi.Infrastructure.Logger
{
    public interface ILoggerWrapper
    {
        void Verbose(string message);
        void Verbose(Exception exception, string message);
        void Verbose<T>(string messageTemplate, T propertyValue);

        void Debug(string message);
        void Debug(Exception exception, string message);
        void Debug<T>(string messageTemplate, T propertyValue);

        void Info(string message);
        void Info(Exception exception, string message);
        void Info<T>(string messageTemplate, T propertyValue);

        void Warn(string message);
        void Warn(Exception exception, string message);
        void Warn<T>(string messageTemplate, T propertyValue);

        void Fatal(string message);
        void Fatal(Exception exception, string message);
        void Fatal<T>(string messageTemplate, T propertyValue);

        void Error(string message);
        void Error(Exception exception, string message);
        void Error<T>(string messageTemplate, T propertyValue);
    }
}
