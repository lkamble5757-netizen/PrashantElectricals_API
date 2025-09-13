using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PrashantApi.Application.Configurations;
using PrashantApi.Application.Interfaces;
using PrashantApi.Application.Interfaces.BranchMaster;
using PrashantApi.Application.Interfaces.Logging;
using PrashantApi.Application.Interfaces.Menu;
using PrashantApi.Application.Interfaces.UserRegistration;
using PrashantApi.Infrastructure.Common;
using PrashantApi.Infrastructure.Connection;
using PrashantApi.Infrastructure.Data;
using PrashantApi.Infrastructure.Logger;
using PrashantApi.Infrastructure.Repositories;
using PrashantApi.Infrastructure.Repositories.BranchMaster;
using PrashantApi.Infrastructure.Services;
using PrashantEle.API.PrashantEle.Domain.Logging;
using System.Reflection;
using System.Security.Claims;
using PrashantApi.Application.Interfaces.ItemMaster;
namespace PrashantApi.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNull(configuration);
        services.AddMediatR(cfg =>
       cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        //  Connections
        services.AddScoped<IDbConnectionString, DbConnectionString>();

        //  Logging
        services.AddScoped<ILog, Log>();

        // Register IExecutionContext
        services.AddScoped<IExecutionContext>(sp =>
        {
            var httpContextAccessor = sp.GetRequiredService<IHttpContextAccessor>();
            var user = httpContextAccessor.HttpContext?.User ?? new ClaimsPrincipal();
            return new UserExecutionContext(user);
        });


        //  Repositories
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IMenuRepository, MenuRepository>();
        services.AddScoped<IUserRegistrationRepository, UserRegistrationRepository>();
        services.AddScoped<IBranchMasterRepository, BranchMasterRepository>();
        services.AddScoped<IItemMasterRepository, ItemMasterRepository>();
        //  Services
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IJwtService, JwtService>();
        services.AddScoped<IUserRegistrationService, UserRegistrationService>();
        services.AddScoped<IMenuService, MenuService>(); 
        services.AddScoped<ILoggerWrapper, LoggerWrapper>(); 
        services.AddScoped<ISqlServerDataAccess, SqlServerDataAccess>(); 
        services.AddScoped<ISqlDbConnection, SqlDbConnection>();
        services.AddScoped<IItemMasterService, ItemMasterService>();



        return services;
    }
}
