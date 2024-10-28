using Application.Common.Interfaces;
using Domain.Entities;
using Infrastructure.Storage.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Storage.Persistence.Repository;

public class Repository<T>(AiTemplatesDbContext context) : IRepository<T>
    where T : Entity
{
    public IQueryable<T> Query()
    {
        return context.Set<T>().AsNoTracking();
    }

    public async Task<T> AddAsync(T item)
    {
        var set = context.Set<T>();
        await set.AddAsync(item);
        await context.SaveChangesAsync();
        return item;
    }

    public async Task<IList<T>> AddRangeAsync(IList<T> items)
    {
        var set = context.Set<T>();
        await set.AddRangeAsync(items);
        await context.SaveChangesAsync();
        return items;
    }

    public async Task<T> UpdateAsync(T item)
    {
        var set = context.Set<T>();
        var original = set.First(entity => entity.Id == item.Id);
        context.Update(original).CurrentValues.SetValues(item);
        await context.SaveChangesAsync();
        return item;
    }

    public async Task<int> HardDeleteAsync(T item)
    {
        var set = context.Set<T>();
        await set.DeleteByKeyAsync(item);
        return await context.SaveChangesAsync();
    }
}