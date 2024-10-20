using Domain.Entities;

namespace Infrastructure.Storage.Persistence.Repository;

public class Repository<T> : IRepository<T> where T : IEntity
{
    // private readonly 
    
    public IQueryable<T> Query()
    {
        throw new NotImplementedException();
    }

    public Task<T> AddAsync(T item)
    {
        throw new NotImplementedException();
    }

    public Task<IList<T>> AddRangeAsync(IList<T> items)
    {
        throw new NotImplementedException();
    }

    public Task<T> UpdateAsync(T item)
    {
        throw new NotImplementedException();
    }

    public Task<int> HardDeleteAsync(T item)
    {
        throw new NotImplementedException();
    }
}