using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PrashantApi.Application.Configurations;
using PrashantApi.Application.Interfaces;
using PrashantApi.Application.Interfaces.BranchMaster;
using PrashantApi.Application.Interfaces.CustomerMaster;
using PrashantApi.Application.Interfaces.ItemMaster;
using PrashantApi.Application.Interfaces.Logging;
using PrashantApi.Application.Interfaces.MachineMaster;
using PrashantApi.Application.Interfaces.MachineMaster.Mapping;
using PrashantApi.Application.Interfaces.Menu;
using PrashantApi.Application.Interfaces.ReferenceDataMaster;
using PrashantApi.Application.Interfaces.RoleMaster;
using PrashantApi.Application.Interfaces.UserRegistration;
using PrashantApi.Infrastructure.Common;
using PrashantApi.Infrastructure.Connection;
using PrashantApi.Infrastructure.Data;
using PrashantApi.Infrastructure.Logger;
using PrashantApi.Infrastructure.Repositories;
using PrashantApi.Infrastructure.Repositories.BranchMaster;
using PrashantApi.Infrastructure.Repositories.CustomerMaster;
using PrashantApi.Infrastructure.Repositories.MachineMaster;
using PrashantApi.Infrastructure.Repositories.ReferenceDataMaster;
using PrashantApi.Infrastructure.Repositories.RoleMaster;
using PrashantApi.Infrastructure.Services;
using PrashantEle.API.PrashantEle.Domain.Logging;
using PrashantEle.API.PrashantEle.Infrastructure.Connection;
using System.Reflection;
using System.Security.Claims;

namespace PrashantApi.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
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
        services.AddScoped<ICustomerMasterRepository, CustomerMasterRepository>();
        services.AddScoped<IMachineMasterRepository, MachineMasterRepository>();
        services.AddScoped<IRoleMasterRepository, RoleMasterRepository>();
        services.AddScoped<IReferenceDataMasterRepository, ReferenceDataMasterRepository>();

        //  Services
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IJwtService, JwtService>();
        services.AddScoped<IUserRegistrationService, UserRegistrationService>();
        services.AddScoped<IMenuService, MenuService>();
        services.AddScoped<ILoggerWrapper, LoggerWrapper>();
        services.AddScoped<ISqlServerDataAccess, SqlServerDataAccess>();
        services.AddScoped<ISqlDbConnection, SqlDbConnection>();
        services.AddScoped<IItemMasterService, ItemMasterService>();
        services.AddScoped<ICustomerMasterService, CustomerMasterService>();
        services.AddScoped<IMachineMasterService, MachineMasterService>();
        services.AddAutoMapper(typeof(MachineMasterProfile).Assembly);
        services.AddTransient<IRoleMasterService, RoleMasterService>();
        services.AddTransient<IReferenceDataMasterService, ReferenceDataMasterService>();







        return services;
    }
}
