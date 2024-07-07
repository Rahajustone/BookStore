using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Serilog;
using static RiverBooks.Users.UserModuleExtensions;
using RiverBooks.Users.Data;

namespace RiverBooks.Users;

public static class UsersModuleExtensions
{
    public static IServiceCollection AddUserModuleServices(
        this IServiceCollection services,
        ConfigurationManager config,
        ILogger logger,
        List<System.Reflection.Assembly> mediatRAssemblies)
    {
        // We use one database for all our applciation
        string? connectionString = config.GetConnectionString("UsersConnectionString");
        services.AddDbContext<UsersDbContext>(config => config.UseSqlServer(connectionString));

        services.AddIdentityCore<ApplicationUser>()
            .AddEntityFrameworkStores<UsersDbContext>();


        // Add User Services
        services.AddScoped<IApplicationUserRepository, EfApplicationUserRepository>();

        mediatRAssemblies.Add(typeof(UsersModuleExtensions).Assembly);

        logger.Information("{Module} module services registered", "Users");

        return services;
    }

}
