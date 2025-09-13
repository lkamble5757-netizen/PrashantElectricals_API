using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace PrashantApi.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Register MediatR from Application assembly
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            // Register AutoMapper from Application assembly
            services.AddAutoMapper(Assembly.GetExecutingAssembly());


            return services;
        }

    }
}
