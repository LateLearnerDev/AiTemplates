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
        var connectionString = configuration.GetConnectionString("LateLearnerDevServer");
        var optionsBuilder = new DbContextOptionsBuilder<AiTemplatesDbContext>();
        // optionsBuilder.UseSqlServer(connectionString!);
        optionsBuilder.UseSqlServer(connectionString, b => b.MigrationsAssembly("Database")); 

        return new AiTemplatesDbContext(optionsBuilder.Options);
    }
}