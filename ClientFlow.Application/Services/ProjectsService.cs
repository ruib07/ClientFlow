using ClientFlow.Application.Interfaces.Repositories;
using ClientFlow.Application.Interfaces.Services;
using ClientFlow.Application.Shared.Common;
using ClientFlow.Domain.Entities;

namespace ClientFlow.Application.Services;

public class ProjectsService : IProjectsService
{
    private readonly IProjectRepository _projectRepository;

    public ProjectsService(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public async Task<List<Project>> GetAllAsync()
    {
        return await _projectRepository.GetAllAsync();
    }

    public async Task<Result<Project>> GetByIdAsync(Guid id)
    {
        var project = await _projectRepository.GetByIdAsync(id);

        if (project == null)
            return Result<Project>.Fail(404, "Project not found");

        return Result<Project>.Success(project);
    }

    public async Task<List<Project>> GetAllByClientIdAsync(Guid clientId)
    {
        return await _projectRepository.GetAllByClientIdAsync(clientId);
    }

    public async Task<Result<Project>> AddAsync(Project project)
    {
        if (project == null)
            return Result<Project>.Fail(400, "Project cannot be null");

        await _projectRepository.AddAsync(project);

        return Result<Project>.Success(project, "Project created successfully.");
    }

    public async Task<Result<Project>> UpdateAsync(Guid id, Project project)
    {
        var existingProject = await _projectRepository.GetByIdAsync(id);

        existingProject.Name = project.Name;
        existingProject.StartDate = project.StartDate;
        existingProject.EndDate = project.EndDate;
        existingProject.Status = project.Status;
        existingProject.Budget = project.Budget;

        await _projectRepository.UpdateAsync(existingProject);

        return Result<Project>.Success(existingProject, "Project updated successfully.");
    }

    public async Task DeleteAsync(Guid id)
    {
        await _projectRepository.DeleteAsync(id);
    }
}
