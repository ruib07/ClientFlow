using ClientFlow.Application.Interfaces.Repositories;
using ClientFlow.Application.Interfaces.Services;
using ClientFlow.Application.Shared.Common;
using ClientFlow.Domain.Entities;

namespace ClientFlow.Application.Services;

public class InteractionsService : IInteractionsService
{
    private readonly IInteractionRepository _interactionRepository;

    public InteractionsService(IInteractionRepository interactionRepository)
    {
        _interactionRepository = interactionRepository;
    }

    public async Task<List<Interaction>> GetAllAsync()
    {
        return await _interactionRepository.GetAllAsync();
    }

    public async Task<Result<Interaction>> GetByIdAsync(Guid id)
    {
        var interaction = await _interactionRepository.GetByIdAsync(id);

        if (interaction == null)
            return Result<Interaction>.Fail(404, "Interaction not found");

        return Result<Interaction>.Success(interaction);
    }

    public async Task<List<Interaction>> GetAllByClientIdAsync(Guid clientId)
    {
        return await _interactionRepository.GetAllByClientIdAsync(clientId);
    }

    public async Task<Result<Interaction>> AddAsync(Interaction interaction)
    {
        if (interaction == null)
            return Result<Interaction>.Fail(400, "Interaction cannot be null");

        await _interactionRepository.AddAsync(interaction);

        return Result<Interaction>.Success(interaction, "Interaction created successfully.");
    }

    public async Task<Result<Interaction>> UpdateAsync(Guid id, Interaction interaction)
    {
        var existingInteraction = await _interactionRepository.GetByIdAsync(id);

        existingInteraction.Type = interaction.Type;
        existingInteraction.Date = interaction.Date;
        existingInteraction.Notes = interaction.Notes;

        await _interactionRepository.UpdateAsync(existingInteraction);

        return Result<Interaction>.Success(existingInteraction, "Interaction updated successfully.");
    }

    public async Task DeleteAsync(Guid id)
    {
        await _interactionRepository.DeleteAsync(id);
    }
}
