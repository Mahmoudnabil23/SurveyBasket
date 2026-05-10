namespace SurveyBasket.Services.Implementations;

public class PollService(IPollRepository pollRepository) : IPollService
{
    private readonly IPollRepository _pollRepo = pollRepository;


    public async Task<IEnumerable<Poll>> GetAllAsync()
    {
        return await _pollRepo.GetAllAsync();
    }

    public async Task<Poll?> GetByIdAsync(object id)
    {
        return await _pollRepo.GetByIdAsync(id);
    }
    public async Task<Poll?> Add(Poll poll)
    {
        _pollRepo.Add(poll);
        return await _pollRepo.SaveAsync() ? poll : null;
    }

    public async Task<bool> Delete(int id)
    {
        Poll? poll = await _pollRepo.GetByIdAsync(id);
        if (poll == null)
        {
            return false;
        }
        _pollRepo.Delete(poll);
        return await _pollRepo.SaveAsync();

    }


    public async Task<bool> Update(int id, Poll poll)
    {
        Poll? _poll = await _pollRepo.GetByIdAsync(id);
        if (_poll is null)
        {
            return false;
        }
        poll.Id = id;
        _pollRepo.Update(poll);
        return await _pollRepo.SaveAsync();

    }
}
