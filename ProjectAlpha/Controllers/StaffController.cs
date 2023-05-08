using Microsoft.AspNetCore.Mvc;
using ProjectAlpha.Entities;
using ProjectAlpha.Repository;

[ApiController]
[Route("api/[controller]")]
public class StaffController : ControllerBase
{
    private readonly IRepository<Staff> _repository;

    public StaffController(IRepository<Staff> repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IEnumerable<Staff>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Staff>> GetByIdAsync(Guid id)
    {
        var activity = await _repository.GetByIdAsync(id);
        if (activity == null)
        {
            return NotFound();
        }

        return activity;
    }

    [HttpPost]
    public async Task<ActionResult<Staff>> AddAsync(Staff staff)
    {
        await _repository.AddAsync(staff);
        return CreatedAtAction(nameof(GetByIdAsync), new { id = staff.Id }, staff);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Staff>> UpdateAsync(Guid id, Staff staff)
    {
        if (id != staff.Id)
        {
            return BadRequest();
        }

        await _repository.UpdateAsync(staff);
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
