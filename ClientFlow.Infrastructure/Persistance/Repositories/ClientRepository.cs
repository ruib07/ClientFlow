using ClientFlow.Application.Interfaces.Repositories;
using ClientFlow.Domain.Entities;
using ClientFlow.Infrastructure.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace ClientFlow.Infrastructure.Persistance.Repositories;

public class ClientRepository : IClientRepository
{
    private readonly ClientFlowDbContext _context;
    private DbSet<Client> Clients => _context.Clients;

    public ClientRepository(ClientFlowDbContext context)
    {
        _context = context;
    }

    public async Task<List<Client>> GetAllAsync()
    {
        return await Clients.AsNoTracking().ToListAsync();
    }

    public async Task<Client> GetByIdAsync(Guid id)
    {
        return await Clients.FirstOrDefaultAsync(c => c.Id.Equals(id));
    }

    public async Task AddAsync(Client client)
    {
        await Clients.AddAsync(client);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Client client)
    {
        Clients.Update(client);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var client = await Clients.SingleOrDefaultAsync(c => c.Id.Equals(id));

        Clients.Remove(client);
        await _context.SaveChangesAsync();
    }
}
