using System.Text.Json.Serialization;

namespace PrashantEle.API.PrashantEle.Application.Common
{
    public class CommandResult
    {
        private CommandResult() { }

        private CommandResult(string failureReason)
        {
            FailureReason = failureReason;
        }

        private CommandResult(object output)
        {
            Output = output;
        }

        public string FailureReason { get; }

        public bool IsSuccess => string.IsNullOrEmpty(FailureReason);

        public static CommandResult Success { get; } = new CommandResult();

        public object Output { get; }


        public static CommandResult Fail(string reason)
        {
            return new CommandResult(reason);
        }

        public static CommandResult Fail(IEnumerable<string> reasons)
        {
            return new CommandResult(string.Join(", ", reasons));
        }

        public static CommandResult SuccessWithOutput(object output)
        {
            return new CommandResult(output);
        }

        public static implicit operator bool(CommandResult result)
        {
            return result.IsSuccess;
        }
    }
    //public class CommandResult<T>
    //{
    //    public bool IsSuccess { get; set; }
    //    public string? ErrorMessage { get; set; }
    //    public T? Data { get; set; }

    //    public static CommandResult<T> SuccessWithOutput(T data)
    //    {
    //        return new CommandResult<T> { IsSuccess = true, Data = data };
    //    }

    //    public static CommandResult<T> Fail(string message)
    //    {
    //        return new CommandResult<T> { IsSuccess = false, ErrorMessage = message };
    //    }
    //}

    public class CommandResult<T>
    {
        [JsonIgnore]
        public bool IsSuccess { get; set; }

        [JsonIgnore]
        public string? ErrorMessage { get; set; }

        public T? Data { get; set; }

        public static CommandResult<T> SuccessWithOutput(T data) =>
            new CommandResult<T> { IsSuccess = true, Data = data };

        public static CommandResult<T> Fail(string message) =>
            new CommandResult<T> { IsSuccess = false, ErrorMessage = message };
    }

}
