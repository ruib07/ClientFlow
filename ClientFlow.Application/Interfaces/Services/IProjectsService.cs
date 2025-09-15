using ClientFlow.Application.Shared.Common;
using ClientFlow.Domain.Entities;

namespace ClientFlow.Application.Interfaces.Services;

public interface IProjectsService
{
    Task<List<Project>> GetAllAsync();
    Task<Result<Project>> GetByIdAsync(Guid id);
    Task<List<Project>> GetAllByClientIdAsync(Guid clientId);
    Task<Result<Project>> AddAsync(Project project);
    Task<Result<Project>> UpdateAsync(Guid id, Project project);
    Task DeleteAsync(Guid id);
}
