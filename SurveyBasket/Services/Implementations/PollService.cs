namespace SurveyBasket.Services.Implementations;

public class PollService(IPollRepository pollRepository) : IPollService
{
    private readonly IPollRepository _pollRepo = pollRepository;


    public async Task<IEnumerable<Poll>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _pollRepo.GetAllAsync(cancellationToken);
    }

    public async Task<Poll?> GetByIdAsync(object id, CancellationToken cancellationToken)
    {
        return await _pollRepo.GetByIdAsync(id, cancellationToken);
    }
    public async Task<Poll?> Add(Poll poll, CancellationToken cancellationToken)
    {
        _pollRepo.Add(poll);
        return await _pollRepo.SaveAsync(cancellationToken) ? poll : null;
    }

    public async Task<bool> Delete(int id, CancellationToken cancellationToken)
    {
        Poll? poll = await _pollRepo.GetByIdAsync(id, cancellationToken);
        if (poll == null)
        {
            return false;
        }
        _pollRepo.Delete(poll);
        return await _pollRepo.SaveAsync(cancellationToken);

    }


    public async Task<bool> Update(int id, Poll poll, CancellationToken cancellationToken)
    {
        Poll? _poll = await _pollRepo.GetByIdAsync(id, cancellationToken);
        if (_poll is null)
        {
            return false;
        }
        poll.Id = id;
        _pollRepo.Update(poll);
        return await _pollRepo.SaveAsync(cancellationToken);

    }
}
