using ClientFlow.Application.Interfaces.Repositories;
using ClientFlow.Domain.Entities;
using ClientFlow.Infrastructure.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace ClientFlow.Infrastructure.Persistance.Repositories;

public class InteractionRepository : IInteractionRepository
{
    private readonly ClientFlowDbContext _context;
    private DbSet<Interaction> Interactions => _context.Interactions;

    public InteractionRepository(ClientFlowDbContext context)
    {
        _context = context;
    }

    public async Task<List<Interaction>> GetAllAsync()
    {
        return await Interactions.AsNoTracking().ToListAsync();
    }

    public async Task<Interaction> GetByIdAsync(Guid id)
    {
        return await Interactions.FirstOrDefaultAsync(i => i.Id.Equals(id));
    }

    public async Task<List<Interaction>> GetAllByClientIdAsync(Guid clientId)
    {
        return await Interactions.AsNoTracking().Where(i => i.ClientId.Equals(clientId)).ToListAsync();
    }

    public async Task AddAsync(Interaction interaction)
    {
        await Interactions.AddAsync(interaction);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Interaction interaction)
    {
        Interactions.Update(interaction);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var interaction = await Interactions.SingleOrDefaultAsync(i => i.Id.Equals(id));

        Interactions.Remove(interaction);
        await _context.SaveChangesAsync();
    }    
}
