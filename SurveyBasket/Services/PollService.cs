namespace SurveyBasket.Services;

public class PollService : IPollService
{

    private static readonly List<Poll> _polls = [
        new Poll { Id = 1, Title = "Favorite Programming Language", Description = "Vote for your favorite programming language." },
        new Poll { Id = 2, Title = "Best Web Framework", Description = "Which web framework do you prefer?" }
    ];

    public IEnumerable<Poll> GetAll()
    {
        return _polls;
    }

    public Poll? Get(int id)
    {
        return _polls.SingleOrDefault(p => p.Id == id);
    }
    public Poll Add(Poll poll)
    {
        poll.Id = _polls.Count + 1;
        _polls.Add(poll);
        return poll;
    }

    public bool Update(int id, Poll poll)
    {
        Poll? pollFromDB = Get(id);
        if (pollFromDB is null)
            return false;
        pollFromDB.Title = poll.Title;
        pollFromDB.Description = poll.Description;
        return true;
    }

    public bool Delete(int id)
    {
        Poll? pollFromDB = Get(id);
        if (pollFromDB is null)
            return false;
        _polls.Remove(pollFromDB);
        return true;
    }
}
