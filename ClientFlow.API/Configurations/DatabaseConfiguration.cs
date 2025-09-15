using ClientFlow.Application.Constants;
using ClientFlow.Infrastructure.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace ClientFlow.API.Configurations;

public static class DatabaseConfiguration
{
    public static void AddCustomDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString(ApiConstants.DatabaseConnString);

        services.AddDbContext<ClientFlowDbContext>(options =>
        {
            options.UseSqlServer(connectionString, sqlServerOptions =>
            {
                var assembly = typeof(ClientFlowDbContext).Assembly;
                var assemblyName = assembly.GetName();

                sqlServerOptions.MigrationsAssembly(assemblyName.Name);
                sqlServerOptions.EnableRetryOnFailure(
                    maxRetryCount: 2,
                    maxRetryDelay: TimeSpan.FromSeconds(30),
                    errorNumbersToAdd: null);
            });
        });
    }
}
