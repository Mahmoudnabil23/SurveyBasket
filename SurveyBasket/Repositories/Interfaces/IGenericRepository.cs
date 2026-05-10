namespace SurveyBasket.Repositories.Interfaces;

public interface IGenericRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T?> GetByIdAsync(object id);
    void Add(T entity);
    void Update(T entity);
    void Delete(T entity);
    Task<bool> SaveAsync();

}
