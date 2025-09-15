using ClientFlow.Application.Shared.Common;
using ClientFlow.Domain.Entities;

namespace ClientFlow.Application.Interfaces.Services;

public interface IInteractionsService
{
    Task<List<Interaction>> GetAllAsync();
    Task<Result<Interaction>> GetByIdAsync(Guid id);
    Task<List<Interaction>> GetAllByClientIdAsync(Guid clientId);
    Task<Result<Interaction>> AddAsync(Interaction interaction);
    Task<Result<Interaction>> UpdateAsync(Guid id, Interaction interaction);
    Task DeleteAsync(Guid id);
}
