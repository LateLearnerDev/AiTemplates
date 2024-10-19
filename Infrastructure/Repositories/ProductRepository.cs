// using Domain.Interfaces;
// using Infrastructure.Persistence.Tables;
// using Microsoft.EntityFrameworkCore;
//
// namespace Infrastructure.Repositories;
//
// public class ProductRepository(AiTemplatesDbContext context) : IProductRepository
// {
//     public async Task<IEnumerable<Product>> GetProductsAsync()
//     {
//         return await context.Products.ToListAsync();
//     }
//     
//     public async Task<Product?> GetProductByIdAsync(Guid id)
//     {
//         return await context.Products.FirstOrDefaultAsync(p => p.Id == id);
//     }
//
//     public async Task<Guid> AddProductAsync(Product product)
//     {
//         var addedItem = await context.Products.AddAsync(product);
//         await context.SaveChangesAsync();
//         return addedItem.Entity.Id;
//     }
//     
//     public async Task UpdateProductAsync(Product product)
//     {
//         context.Products.Update(product);
//         await context.SaveChangesAsync();
//     }
// }