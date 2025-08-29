using PrashantApi.Application.Interfaces;

namespace PrashantApi.Infrastructure.Services;

public class SampleService : ISampleService
{
    public string GetMessage() => "Hello from Infrastructure Service!";
}
