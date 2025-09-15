using ClientFlow.APIClient.Interfaces;
using ClientFlow.Domain.Entities;
using System.Net.Http.Json;

namespace ClientFlow.APIClient.Contracts;

public class ProjectsAPIService : IProjectsAPIService
{
    private readonly HttpClient _httpClient;
    private const string _baseUri = "Projects";

    public ProjectsAPIService(HttpClient httpClient)
    {
        _httpClient=httpClient;
    }

    public async Task<List<Project>> GetProjects()
    {
        return await _httpClient.GetFromJsonAsync<List<Project>>(_baseUri);
    }

    public async Task<Project> GetProject(Guid projectId)
    {
        return await _httpClient.GetFromJsonAsync<Project>($"{_baseUri}/{projectId}");
    }

    public async Task<List<Project>> GetProjectsByClient(Guid clientId)
    {
        return await _httpClient.GetFromJsonAsync<List<Project>>($"{_baseUri}/Client/{clientId}");
    }

    public async Task<Project> AddProject(Project project)
    {
        var response = await _httpClient.PostAsJsonAsync(_baseUri, project);

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<Project>();
    }

    public async Task<Project> UpdateProject(Guid projectId, Project project)
    {
        var response = await _httpClient.PutAsJsonAsync($"{_baseUri}/{projectId}", project);

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<Project>();
    }

    public async Task DeleteProject(Guid projectId)
    {
        var response = await _httpClient.DeleteAsync($"{_baseUri}/{projectId}");

        response.EnsureSuccessStatusCode();
    }
}
