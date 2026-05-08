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
        IEnumerable<PollResponse> response = _polls.Adapt<IEnumerable<PollResponse>>();
        return Ok(response);
    }

    [HttpGet("{id:int}")]
    public IActionResult Get(int id)
    {
        Poll? _poll = _pollService.Get(id);
        if (_poll is null)
        {
            return NotFound();
        }
        PollResponse response = _poll.Adapt<PollResponse>();
        return Ok(response);
    }

    [HttpPost("")]
    public IActionResult Add(CreatePollRequest request)
    {
        Poll _poll = _pollService.Add(request.Adapt<Poll>());
        return CreatedAtAction(nameof(Get), new { id = _poll.Id }, _poll);
    }

    [HttpPut("{id:int}")]
    public IActionResult Update(int id, CreatePollRequest request)
    {
        bool IsUpdated = _pollService.Update(id, request.Adapt<Poll>());
        return IsUpdated ? NoContent() : NotFound();
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        bool IsDeleted = _pollService.Delete(id);
        return IsDeleted ? NoContent() : NotFound();
    }
}
