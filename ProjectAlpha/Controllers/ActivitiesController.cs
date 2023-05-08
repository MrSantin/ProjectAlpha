using Microsoft.AspNetCore.Mvc;
using ProjectAlpha.Entities;
using ProjectAlpha.Repository;

[ApiController]
[Route("api/[controller]")]
public class ActivityController : ControllerBase
{
    private readonly IRepository<Activity> _activityRepository;

    public ActivityController(IRepository<Activity> activityRepository)
    {
        _activityRepository = activityRepository;
    }

    [HttpGet]
    public async Task<IEnumerable<Activity>> GetAllAsync()
    {
        return await _activityRepository.GetAllAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Activity>> GetByIdAsync(Guid id)
    {
        var activity = await _activityRepository.GetByIdAsync(id);
        if (activity == null)
        {
            return NotFound();
        }

        return activity;
    }

    [HttpPost]
    public async Task<ActionResult<Activity>> AddAsync(Activity activity)
    {
        await _activityRepository.AddAsync(activity);
        return CreatedAtAction(nameof(GetByIdAsync), new { id = activity.Id }, activity);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Activity>> UpdateAsync(Guid id, Activity activity)
    {
        if (id != activity.Id)
        {
            return BadRequest();
        }

        await _activityRepository.UpdateAsync(activity);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteAsync(Guid id)
    {
        var result = await _activityRepository.DeleteAsync(id);
        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }
}
