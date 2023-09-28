using System;
namespace FilmApi.Data.Repositories
{
    // General repository interface for CRUD (Crate, Update, Read, Delete) handling.
    public interface ICrudRepository<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
    }
}