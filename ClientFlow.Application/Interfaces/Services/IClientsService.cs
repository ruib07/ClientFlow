using ClientFlow.Application.Shared.Common;
using ClientFlow.Domain.Entities;

namespace ClientFlow.Application.Interfaces.Services;

public interface IClientsService
{
    Task<List<Client>> GetAllAsync();
    Task<Result<Client>> GetByIdAsync(Guid id);
    Task<Result<Client>> AddAsync(Client client);
    Task<Result<Client>> UpdateAsync(Guid id, Client client);
    Task DeleteAsync(Guid id);
}
