using System;

namespace FilmApi.Services
{
    internal interface ICrudService<T, ID>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(ID id);
        Task<T> AddAsync(T obj);
        Task<T> UpdateAsync(T obj);
        Task DeleteAsync(ID id);
    }
}