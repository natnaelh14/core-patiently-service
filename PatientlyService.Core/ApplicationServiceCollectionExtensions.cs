using FluentValidation;
using PatientlyService.Core.Database;
using PatientlyService.Core.Repositories;
using PatientlyService.Core.Services;

namespace PatientlyService.Core;

public static class ApplicationServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddSingleton<ITenantRepository, TenantRepository>();
        services.AddSingleton<ITenantService, TenantService>();
        services.AddSingleton<IUserInviteRepository, UserInviteRepository>();
        services.AddSingleton<IUserInviteService, UserInviteService>();
        services.AddSingleton<IUserRepository, UserRepository>();
        services.AddSingleton<IUserService, UserService>();
        services.AddSingleton<IPermissionRepository, PermissionRepository>();
        services.AddSingleton<IPermissionService, PermissionService>();
        services.AddValidatorsFromAssemblyContaining<IApplicationMarker>(ServiceLifetime.Singleton);
        return services;
    }

    public static IServiceCollection AddDatabase(this IServiceCollection services,
        string connectionString)
    {
        services.AddSingleton<IDbConnectionFactory>(_ => 
            new NpgsqlConnectionFactory(connectionString));
        services.AddSingleton<DbInitializer>();
        return services;
    }
}