namespace SurveyBasket.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PollsController(IPollService pollService) : ControllerBase
{
    private readonly IPollService _pollService = pollService;

    [HttpGet("")]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        IEnumerable<Poll> _polls = await _pollService.GetAllAsync(cancellationToken);
        IEnumerable<PollResponse> response = _polls.Adapt<IEnumerable<PollResponse>>();
        return Ok(response);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
    {
        Poll? _poll = await _pollService.GetByIdAsync(id, cancellationToken);
        if (_poll is null)
        {
            return NotFound();
        }
        PollResponse response = _poll.Adapt<PollResponse>();
        return Ok(response);
    }

    [HttpPost("")]
    public async Task<IActionResult> Add([FromBody] PollRequest request, CancellationToken cancellationToken)
    {
        Poll? _poll = await _pollService.Add(request.Adapt<Poll>(), cancellationToken);
        if (_poll is null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(GetById), new { id = _poll.Id }, _poll);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] PollRequest request, CancellationToken cancellationToken)
    {
        bool IsUpdated = await _pollService.Update(id, request.Adapt<Poll>(), cancellationToken);
        return IsUpdated ? NoContent() : NotFound();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        bool IsDeleted = await _pollService.Delete(id, cancellationToken);
        return IsDeleted ? NoContent() : NotFound();
    }

    [HttpPut("{id:int}/toggle")]
    public async Task<IActionResult> TogglePublishStatus([FromRoute] int id, CancellationToken cancellationToken)
    {
        bool IsToggled = await _pollService.TogglePublishStatus(id, cancellationToken);
        return IsToggled ? NoContent() : NotFound();
    }
}
