using ClientFlow.Domain.Entities;

namespace ClientFlow.Application.Interfaces.Repositories;

public interface IInteractionRepository
{
    Task<List<Interaction>> GetAllAsync();
    Task<Interaction> GetByIdAsync(Guid id);
    Task<List<Interaction>> GetAllByClientIdAsync(Guid clientId);
    Task AddAsync(Interaction interaction);
    Task UpdateAsync(Interaction interaction);
    Task DeleteAsync(Guid id);
}
