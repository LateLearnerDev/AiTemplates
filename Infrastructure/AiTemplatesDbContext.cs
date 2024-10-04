using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class AiTemplatesDbContext(DbContextOptions<AiTemplatesDbContext> options) : DbContext(options)
{
    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}