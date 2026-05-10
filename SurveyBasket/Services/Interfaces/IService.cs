namespace SurveyBasket.Services.Interfaces;

public interface IService<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken);
    Task<T?> GetByIdAsync(object id, CancellationToken cancellationToken);
    Task<T?> Add(T poll, CancellationToken cancellationToken);
    Task<bool> Update(int id, T poll, CancellationToken cancellationToken);
    Task<bool> Delete(int id, CancellationToken cancellationToken);

}
