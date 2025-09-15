using Asp.Versioning;
using ClientFlow.Application.Interfaces.Services;
using ClientFlow.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ClientFlow.API.Controllers;

[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1")]
public class ProjectsController : ControllerBase
{
    private readonly IProjectsService _projectsService;

    public ProjectsController(IProjectsService projectsService)
    {
        _projectsService = projectsService;
    }

    // GET api/v1/Projects
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<List<Project>>> GetProjects()
    {
        return Ok(await _projectsService.GetAllAsync());
    }

    // GET api/v1/Projects/{id}
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetProjectById(Guid id)
    {
        var result = await _projectsService.GetByIdAsync(id);

        if (!result.IsSuccess) return StatusCode(result.Error.StatusCode, result.Error);

        return Ok(result.Data);
    }

    // GET api/v1/Projects/Client/{clientId}
    [HttpGet("client/{clientId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<List<Project>>> GetProjectsByClientId(Guid clientId)
    {
        return Ok(await _projectsService.GetAllByClientIdAsync(clientId));
    }

    // POST api/v1/Projects
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> AddProject([FromBody] Project project)
    {
        var result = await _projectsService.AddAsync(project);

        if (!result.IsSuccess)
            return StatusCode(result.Error.StatusCode, result.Error);

        return StatusCode(StatusCodes.Status201Created, result.Data);
    }

    // PUT api/v1/Projects/{id}
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdateProject(Guid id, [FromBody] Project updateProject)
    {
        var result = await _projectsService.UpdateAsync(id, updateProject);

        if (!result.IsSuccess) return StatusCode(result.Error.StatusCode, result.Error);

        return Ok(result.Message);
    }

    // DELETE api/v1/Projects/{id}
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeleteProject(Guid id)
    {
        await _projectsService.DeleteAsync(id);

        return NoContent();
    }
}
