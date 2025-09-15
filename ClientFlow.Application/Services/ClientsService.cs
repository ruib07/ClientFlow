using ClientFlow.Application.Interfaces.Repositories;
using ClientFlow.Application.Interfaces.Services;
using ClientFlow.Application.Shared.Common;
using ClientFlow.Domain.Entities;

namespace ClientFlow.Application.Services;

public class ClientsService : IClientsService
{
    private readonly IClientRepository _clientRepository;

    public ClientsService(IClientRepository clientRepository)
    {
        _clientRepository = clientRepository;
    }

    public async Task<List<Client>> GetAllAsync()
    {
        return await _clientRepository.GetAllAsync();
    }

    public async Task<Result<Client>> GetByIdAsync(Guid id)
    {
        var client = await _clientRepository.GetByIdAsync(id);

        if (client == null)
            return Result<Client>.Fail(404, "Client not found");

        return Result<Client>.Success(client);
    }

    public async Task<Result<Client>> AddAsync(Client client)
    {
        if (client == null)
            return Result<Client>.Fail(400, "Client cannot be null");

        await _clientRepository.AddAsync(client);

        return Result<Client>.Success(client, "Client created successfully.");
    }

    public async Task<Result<Client>> UpdateAsync(Guid id, Client client)
    {
        var existingClient = await _clientRepository.GetByIdAsync(id);

        existingClient.Company = client.Company;
        existingClient.Contact = client.Contact;
        existingClient.Email = client.Email;
        existingClient.Phone = client.Phone;
        existingClient.Address = client.Address;

        await _clientRepository.UpdateAsync(existingClient);

        return Result<Client>.Success(existingClient, "Client updated successfully.");
    }

    public async Task DeleteAsync(Guid id)
    {
        await _clientRepository.DeleteAsync(id);
    }
}
