using PrashantEle.API.PrashantEle.Domain.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;
using System;
using Log = Serilog.Log;

namespace PrashantApi.Infrastructure.Logger
{
    public class LoggerWrapper : ILoggerWrapper
    {
        public void Verbose(string message)
        {
            Log.Verbose(message);
        }
        public void Verbose(Exception exception, string message)
        {
            Log.Verbose(exception, message);
        }
        public void Verbose<T>(string message, T property)
        {
            Log.Verbose(message, property);
        }


        public void Debug(string message)
        {
            Log.Debug(message);
        }
        public void Debug(Exception exception, string message)
        {
            Log.Debug(exception, message);
        }
        public void Debug<T>(string message, T property)
        {
            Log.Debug(message, property);
        }


        public void Info(string message)
        {
            Log.Information(message);
        }
        public void Info(Exception exception, string message)
        {
            Log.Information(exception, message);
        }
        public void Info<T>(string message, T property)
        {
            Log.Information(message, property);
        }


        public void Warn(string message)
        {
            Log.Warning(message);
        }
        public void Warn(Exception exception, string message)
        {
            Log.Warning(exception, message);
        }
        public void Warn<T>(string message, T property)
        {
            Log.Warning(message, property);
        }


        public void Fatal(string message)
        {
            Log.Fatal(message);
        }
        public void Fatal(Exception exception, string message)
        {
            Log.Fatal(exception, message);
        }
        public void Fatal<T>(string message, T property)
        {
            Log.Fatal(message, property);
        }

        public void Error(string message)
        {
            Log.Error(message);
        }
        public void Error(Exception exception, string message)
        {
            Log.Error(exception, message);
        }
        public void Error<T>(string message, T property)
        {
            Log.Error(message, property);
        }
    }
}
