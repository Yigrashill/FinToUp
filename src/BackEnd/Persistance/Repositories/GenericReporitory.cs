
using Application.Contracts.Persistance;

namespace Persistance.Repositories;

public class GenericReporitory<T> : IGenericRepository<T> where T : class
{
    public Task<T> CreateAsync(T entity)
    {
        throw new NotImplementedException();
    }

    public Task<T> DeleteAsync(T entity)
    {
        throw new NotImplementedException();
    }

    public Task<List<T>> GetAsync()
    {
        throw new NotImplementedException();
    }

    public Task<T> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<T> UpdateAsync(T entity)
    {
        throw new NotImplementedException();
    }
}
