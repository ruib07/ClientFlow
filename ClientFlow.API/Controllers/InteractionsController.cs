using Asp.Versioning;
using ClientFlow.Application.Interfaces.Services;
using ClientFlow.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ClientFlow.API.Controllers;

[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1")]
public class InteractionsController : ControllerBase
{
    private readonly IInteractionsService _interactionsService;

    public InteractionsController(IInteractionsService interactionsService)
    {
        _interactionsService = interactionsService;
    }

    // GET api/v1/Interactions
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<List<Interaction>>> GetInteractions()
    {
        return Ok(await _interactionsService.GetAllAsync());
    }

    // GET api/v1/Interactions/{id}
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetInteractionById(Guid id)
    {
        var result = await _interactionsService.GetByIdAsync(id);

        if (!result.IsSuccess) return StatusCode(result.Error.StatusCode, result.Error);

        return Ok(result.Data);
    }

    // GET api/v1/Interactions/Client/{clientId}
    [HttpGet("client/{clientId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<List<Interaction>>> GetInteractionsByClientId(Guid clientId)
    {
        return Ok(await _interactionsService.GetAllByClientIdAsync(clientId));
    }

    // POST api/v1/Interactions
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> AddInteraction([FromBody] Interaction interaction)
    {
        var result = await _interactionsService.AddAsync(interaction);

        if (!result.IsSuccess)
            return StatusCode(result.Error.StatusCode, result.Error);

        return StatusCode(StatusCodes.Status201Created, result.Data);
    }

    // PUT api/v1/Interactions/{id}
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdateInteraction(Guid id, [FromBody] Interaction updateInteraction)
    {
        var result = await _interactionsService.UpdateAsync(id, updateInteraction);

        if (!result.IsSuccess) return StatusCode(result.Error.StatusCode, result.Error);

        return Ok(result.Message);
    }

    // DELETE api/v1/Interactions/{id}
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeleteInteraction(Guid id)
    {
        await _interactionsService.DeleteAsync(id);

        return NoContent();
    }
}
