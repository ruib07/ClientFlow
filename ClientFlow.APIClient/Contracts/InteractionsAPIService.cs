using ClientFlow.APIClient.Interfaces;
using ClientFlow.Domain.Entities;
using System.Net.Http.Json;

namespace ClientFlow.APIClient.Contracts;

public class InteractionsAPIService : IInteractionsAPIService
{
    private readonly HttpClient _httpClient;
    private const string _baseUri = "Interactions";

    public InteractionsAPIService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Interaction>> GetInteractions()
    {
        return await _httpClient.GetFromJsonAsync<List<Interaction>>(_baseUri);
    }

    public async Task<Interaction> GetInteraction(Guid interactionId)
    {
        return await _httpClient.GetFromJsonAsync<Interaction>($"{_baseUri}/{interactionId}");
    }

    public async Task<List<Interaction>> GetInteractionsByClient(Guid clientId)
    {
        return await _httpClient.GetFromJsonAsync<List<Interaction>>($"{_baseUri}/Client/{clientId}");
    }

    public async Task<Interaction> AddInteraction(Interaction interaction)
    {
        var response = await _httpClient.PostAsJsonAsync(_baseUri, interaction);

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<Interaction>();
    }

    public async Task<Interaction> UpdateInteraction(Guid interactionId, Interaction interaction)
    {
        var response = await _httpClient.PutAsJsonAsync($"{_baseUri}/{interactionId}", interaction);

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<Interaction>();
    }

    public async Task DeleteInteraction(Guid interactionId)
    {
        var response = await _httpClient.DeleteAsync($"{_baseUri}/{interactionId}");

        response.EnsureSuccessStatusCode();
    }
}
