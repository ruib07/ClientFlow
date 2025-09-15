using ClientFlow.Domain.Entities;

namespace ClientFlow.APIClient.Interfaces;

public interface IClientsAPIService
{
    Task<List<Client>> GetClients();
    Task<Client> GetClient(Guid clientId);
    Task<Client> AddClient(Client client);
    Task<Client> UpdateClient(Guid clientId, Client client);
    Task DeleteClient(Guid clientId);
}
