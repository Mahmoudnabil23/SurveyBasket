namespace SurveyBasket.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PollsController(IPollService pollService) : ControllerBase
{
    private readonly IPollService _pollService = pollService;

    [HttpGet("")]
    public async Task<IActionResult> GetAll()
    {
        IEnumerable<Poll> _polls = await _pollService.GetAllAsync();
        IEnumerable<PollResponse> response = _polls.Adapt<IEnumerable<PollResponse>>();
        return Ok(response);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        Poll? _poll = await _pollService.GetByIdAsync(id);
        if (_poll is null)
        {
            return NotFound();
        }
        PollResponse response = _poll.Adapt<PollResponse>();
        return Ok(response);
    }

    [HttpPost("")]
    public async Task<IActionResult> Add([FromBody] CreatePollRequest request)
    {
        Poll? _poll = await _pollService.Add(request.Adapt<Poll>());
        if (_poll is null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(GetById), new { id = _poll.Id }, _poll);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] CreatePollRequest request)
    {
        bool IsUpdated = await _pollService.Update(id, request.Adapt<Poll>());
        return IsUpdated ? NoContent() : NotFound();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        bool IsDeleted = await _pollService.Delete(id);
        return IsDeleted ? NoContent() : NotFound();
    }
}
