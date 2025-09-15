using ClientFlow.APIClient.Contracts;
using ClientFlow.APIClient.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ClientFlow.APIClient;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddClientFlowServices(this IServiceCollection services, IConfiguration configuration)
    {
        var apiUrl = configuration["Api:BaseUrl"] ??
            throw new InvalidOperationException("ApiBaseUrl not configured.");

        if (!apiUrl.EndsWith('/')) apiUrl += '/';

        services.AddHttpClient("ClientFlowAPI", client =>
        {
            client.BaseAddress = new Uri(apiUrl, UriKind.Absolute);
        });

        services.AddScoped<IClientsAPIService, ClientsAPIService>();
        services.AddScoped<IInteractionsAPIService, InteractionsAPIService>();
        services.AddScoped<IProjectsAPIService, ProjectsAPIService>();

        return services;
    }
}
