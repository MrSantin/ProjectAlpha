using Microsoft.AspNetCore.Mvc;
using ProjectAlpha.Entities;
using ProjectAlpha.Repository;

[ApiController]
[Route("api/[controller]")]
public class MessageController : ControllerBase
{
    private readonly IRepository<Message> _repository;

    public MessageController(IRepository<Message> messageRepository)
    {
        _repository = messageRepository;
    }

    [HttpGet]
    public async Task<IEnumerable<Message>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Message>> GetByIdAsync(Guid id)
    {
        var activity = await _repository.GetByIdAsync(id);
        if (activity == null)
        {
            return NotFound();
        }

        return activity;
    }

    [HttpPost]
    public async Task<ActionResult<Message>> AddAsync(Message message)
    {
        await _repository.AddAsync(message);
        return CreatedAtAction(nameof(GetByIdAsync), new { id = message.Id }, message);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Message>> UpdateAsync(Guid id, Message message)
    {
        if (id != message.Id)
        {
            return BadRequest();
        }

        await _repository.UpdateAsync(message);
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
