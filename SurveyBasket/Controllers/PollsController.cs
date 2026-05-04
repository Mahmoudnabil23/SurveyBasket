namespace SurveyBasket.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PollsController(IPollService pollService) : ControllerBase
{
    private readonly IPollService _pollService = pollService;

    [HttpGet("")]
    public IActionResult GetAll()
    {
        IEnumerable<Poll> _polls = _pollService.GetAll();
        return Ok(_polls);
    }

    [HttpGet("{id:int}")]
    public IActionResult Get(int id)
    {
        Poll? _poll = _pollService.Get(id);
        return _poll is null ? NotFound() : Ok(_poll);
    }

    [HttpPost("")]
    public IActionResult Add(Poll poll)
    {
        Poll _poll = _pollService.Add(poll);
        return CreatedAtAction(nameof(Get), new { id = poll.Id }, _poll);
    }

    [HttpPut("{id:int}")]
    public IActionResult Update(int id, Poll poll)
    {
        bool IsUpdated = _pollService.Update(id, poll);
        return IsUpdated ? NoContent() : NotFound();
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        bool IsDeleted = _pollService.Delete(id);
        return IsDeleted ? NoContent() : NotFound();
    }
}
