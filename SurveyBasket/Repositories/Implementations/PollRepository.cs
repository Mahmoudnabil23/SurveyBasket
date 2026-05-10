namespace SurveyBasket.Repositories.Implementations;

public class PollRepository(ApplicationDbContext context) : GenericRepository<Poll>(context), IPollRepository
{

}
