using Asp.Versioning;
using ClientFlow.Application.Interfaces.Services;
using ClientFlow.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ClientFlow.API.Controllers;

[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1")]
public class ClientsController : ControllerBase
{
    private readonly IClientsService _clientsService;

    public ClientsController(IClientsService clientsService)
    {
        _clientsService = clientsService;
    }

    // GET api/v1/Clients
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<List<Client>>> GetClients()
    {
        return Ok(await _clientsService.GetAllAsync());
    }

    // GET api/v1/Clients/{id}
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetClientById(Guid id)
    {
        var result = await _clientsService.GetByIdAsync(id);

        if (!result.IsSuccess) return StatusCode(result.Error.StatusCode, result.Error);

        return Ok(result.Data);
    }

    // POST api/v1/Clients
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> AddClient([FromBody] Client client)
    {
        var result = await _clientsService.AddAsync(client);

        if (!result.IsSuccess)
            return StatusCode(result.Error.StatusCode, result.Error);

        return StatusCode(StatusCodes.Status201Created, result.Data);
    }

    // PUT api/v1/Clients/{id}
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdateClient(Guid id, [FromBody] Client updateClient)
    {
        var result = await _clientsService.UpdateAsync(id, updateClient);

        if (!result.IsSuccess) return StatusCode(result.Error.StatusCode, result.Error);

        return Ok(result.Message);
    }

    // DELETE api/v1/Clients/{id}
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeleteClient(Guid id)
    {
        await _clientsService.DeleteAsync(id);

        return NoContent();
    }
}
