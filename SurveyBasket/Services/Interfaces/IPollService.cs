namespace SurveyBasket.Services.Interfaces;

public interface IPollService : IService<Poll>
{
    Task<bool> TogglePublishStatus(int id, CancellationToken cancellationToken);
}
