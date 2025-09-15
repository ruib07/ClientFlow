using ClientFlow.Domain.Entities;

namespace ClientFlow.APIClient.Interfaces;

public interface IInteractionsAPIService
{
    Task<List<Interaction>> GetInteractions();
    Task<Interaction> GetInteraction(Guid interactionId);
    Task<List<Interaction>> GetInteractionsByClient(Guid clientId);
    Task<Interaction> AddInteraction(Interaction interaction);
    Task<Interaction> UpdateInteraction(Guid interactionId, Interaction interaction);
    Task DeleteInteraction(Guid interactionId);
}
