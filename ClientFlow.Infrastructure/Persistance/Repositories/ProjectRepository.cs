using ClientFlow.Application.Interfaces.Repositories;
using ClientFlow.Domain.Entities;
using ClientFlow.Infrastructure.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace ClientFlow.Infrastructure.Persistance.Repositories;

public class ProjectRepository : IProjectRepository
{
    private readonly ClientFlowDbContext _context;
    private DbSet<Project> Projects => _context.Projects;

    public ProjectRepository(ClientFlowDbContext context)
    {
        _context = context;
    }

    public async Task<List<Project>> GetAllAsync()
    {
        return await Projects.AsNoTracking().ToListAsync();
    }

    public async Task<Project> GetByIdAsync(Guid id)
    {
        return await Projects.FirstOrDefaultAsync(p => p.Id.Equals(id));
    }

    public async Task<List<Project>> GetAllByClientIdAsync(Guid clientId)
    {
        return await Projects.AsNoTracking().Where(p => p.ClientId.Equals(clientId)).ToListAsync();
    }

    public async Task AddAsync(Project project)
    {
        await Projects.AddAsync(project);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Project project)
    {
        Projects.Update(project);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var project = await Projects.SingleOrDefaultAsync(p => p.Id.Equals(id));

        Projects.Remove(project);
        await _context.SaveChangesAsync();
    }    
}
