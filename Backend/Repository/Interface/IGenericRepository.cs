namespace Backend.Contracts
{
    public interface IGenericRepository<T> where T: class
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetAsync(int? id);
        Task<T> CreatAsync(T entity);
        Task UpdateAsync(T entity);   
        Task DeleteAsync(int id);
        Task<bool> Exists(int id);
    }
}
