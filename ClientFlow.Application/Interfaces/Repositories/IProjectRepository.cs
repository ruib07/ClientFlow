using ClientFlow.Domain.Entities;

namespace ClientFlow.Application.Interfaces.Repositories;

public interface IProjectRepository
{
    Task<List<Project>> GetAllAsync();
    Task<Project> GetByIdAsync(Guid id);
    Task<List<Project>> GetAllByClientIdAsync(Guid clientId);
    Task AddAsync(Project project);
    Task UpdateAsync(Project project);
    Task DeleteAsync(Guid id);
}
