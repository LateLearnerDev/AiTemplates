using Domain.Entities;

namespace Application.Common.Interfaces;

public interface IRepository<T> where T : Entity
{
    IQueryable<T> Query();
    
    Task<T> AddAsync(T item);
    Task<IList<T>> AddRangeAsync(IList<T> items);
    Task<T> UpdateAsync(T item);

    Task<int> HardDeleteAsync(T item);
}