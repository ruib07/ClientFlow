using ClientFlow.Domain.Entities;

namespace ClientFlow.Application.Interfaces.Repositories;

public interface IClientRepository
{
    Task<List<Client>> GetAllAsync();
    Task<Client> GetByIdAsync(Guid id);
    Task AddAsync(Client client);
    Task UpdateAsync(Client client);
    Task DeleteAsync(Guid id);
}
