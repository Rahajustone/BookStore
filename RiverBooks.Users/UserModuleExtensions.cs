using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace RiverBooks.Users;

public static partial class UserModuleExtensions
{
    public static IServiceCollection AddUserModuleServices(
        this IServiceCollection services,
        ConfigurationManager config,
        ILogger logger)
    {
        // We use one database for all our applciation
        string? connectionString = config.GetConnectionString("UsersConnectionString");
        services.AddDbContext<UsersDbContext>(config => config.UseSqlServer(connectionString));

        services.AddIdentityCore<ApplicationUser>()
            .AddEntityFrameworkStores<UsersDbContext>();

        logger.Information("{Module} module services registered", "Users");

        return services;
    }

}
