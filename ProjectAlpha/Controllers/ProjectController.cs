using Microsoft.AspNetCore.Mvc;
using ProjectAlpha.Entities;
using ProjectAlpha.Repository;

[ApiController]
[Route("api/[controller]")]
public class ProjectController : ControllerBase
{
    private readonly IRepository<Project> _repository;

    public ProjectController(IRepository<Project> repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IEnumerable<Project>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Project>> GetByIdAsync(Guid id)
    {
        var activity = await _repository.GetByIdAsync(id);
        if (activity == null)
        {
            return NotFound();
        }

        return activity;
    }

    [HttpPost]
    public async Task<ActionResult<Project>> AddAsync(Project project)
    {
        await _repository.AddAsync(project);
        return CreatedAtAction(nameof(GetByIdAsync), new { id = project.Id }, project);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Project>> UpdateAsync(Guid id, Project project)
    {
        if (id != project.Id)
        {
            return BadRequest();
        }

        await _repository.UpdateAsync(project);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteAsync(Guid id)
    {
        var result = await _repository.DeleteAsync(id);
        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }
}
