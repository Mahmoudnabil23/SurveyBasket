namespace SurveyBasket.Services.Interfaces;

public interface IService<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T?> GetByIdAsync(object id);
    Task<T?> Add(T poll);
    Task<bool> Update(int id, T poll);
    Task<bool> Delete(int id);

}
