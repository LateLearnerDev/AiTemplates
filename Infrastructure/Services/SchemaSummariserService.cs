using System.Text;
using Application.SchemaSummariser;
using Application.SchemaSummariser.Services;
using Infrastructure.Storage.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Infrastructure.Services;

public class SchemaSummariserService(AiTemplatesDbContext context) : ISchemaSummariserService
{
    public string GetSummarizedSchema()
    {
        var builder = new StringBuilder();
        var entityTypes = context.Model.GetEntityTypes();

        foreach (var entityType in entityTypes)
        {
            var tableName = entityType.GetTableName();
            builder.AppendLine($"Table: {tableName}");

            AppendColumns(entityType, builder);

            AppendRelationships(entityType, builder);

            builder.AppendLine(); 
        }

        return builder.ToString();
    }

    private static void AppendRelationships(IEntityType entityType, StringBuilder builder)
    {
        foreach (var foreignKey in entityType.GetForeignKeys())
        {
            var principalTable = foreignKey.PrincipalEntityType.GetTableName();
            builder.AppendLine($"  Foreign Key: {foreignKey.DependentToPrincipal?.Name} -> {principalTable}");
        }
    }

    private static void AppendColumns(IEntityType entityType, StringBuilder builder)
    {
        foreach (var property in entityType.GetProperties())
        {
            builder.AppendLine($"  Column: {property.Name} ({property.ClrType.Name})");
        }
    }
}

