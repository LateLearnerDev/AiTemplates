using Domain.Entities;

namespace Infrastructure.Storage.Persistence.Repository;

public interface IRepository<T> where T : IEntity
{
    IQueryable<T> Query();
    
    Task<T> AddAsync(T item);
    Task<IList<T>> AddRangeAsync(IList<T> items);
    Task<T> UpdateAsync(T item);

    Task<int> HardDeleteAsync(T item);
}