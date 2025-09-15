using ClientFlow.Domain.Entities;

namespace ClientFlow.APIClient.Interfaces;

public interface IProjectsAPIService
{
    Task<List<Project>> GetProjects();
    Task<Project> GetProject(Guid projectId);
    Task<List<Project>> GetProjectsByClient(Guid clientId);
    Task<Project> AddProject(Project project);
    Task<Project> UpdateProject(Guid projectId, Project project);
    Task DeleteProject(Guid projectId);
}
