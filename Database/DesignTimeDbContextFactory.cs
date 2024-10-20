using Infrastructure.Storage.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Database;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AiTemplatesDbContext>
{
    public AiTemplatesDbContext CreateDbContext(string[] args)
    {
        // Build configuration
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        // Create DbContextOptionsBuilder with the connection string
        var connectionString = configuration.GetConnectionString("PostgresConnection");
        var optionsBuilder = new DbContextOptionsBuilder<AiTemplatesDbContext>();
        // optionsBuilder.UseMySQL(connectionString);
        optionsBuilder.UseNpgsql(connectionString, b => b.MigrationsAssembly("Database")); 

        return new AiTemplatesDbContext(optionsBuilder.Options);
    }
}