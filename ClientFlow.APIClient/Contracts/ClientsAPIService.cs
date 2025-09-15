using ClientFlow.APIClient.Interfaces;
using ClientFlow.Domain.Entities;
using System.Net.Http.Json;

namespace ClientFlow.APIClient.Contracts;

public class ClientsAPIService : IClientsAPIService
{
    private readonly HttpClient _httpClient;
    private const string _baseUri = "Clients";

    public ClientsAPIService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Client>> GetClients()
    {
        return await _httpClient.GetFromJsonAsync<List<Client>>(_baseUri);
    }

    public async Task<Client> GetClient(Guid clientId)
    {
        return await _httpClient.GetFromJsonAsync<Client>($"{_baseUri}/{clientId}");
    }

    public async Task<Client> AddClient(Client client)
    {
        var response = await _httpClient.PostAsJsonAsync(_baseUri, client);

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<Client>();
    }

    public async Task<Client> UpdateClient(Guid clientId, Client client)
    {
        var response = await _httpClient.PutAsJsonAsync($"{_baseUri}/{clientId}", client);

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<Client>();
    }

    public async Task DeleteClient(Guid clientId)
    {
        var response = await _httpClient.DeleteAsync($"{_baseUri}/{clientId}");

        response.EnsureSuccessStatusCode();
    }
}
