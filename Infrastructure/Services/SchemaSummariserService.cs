using System.Text;
using Application.SchemaSummariser;
using Application.SchemaSummariser.Services;
using Infrastructure.Storage.Persistence.Context;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Services;

public class SchemaSummariserService(AiTemplatesDbContext context, IConfiguration configuration) : ISchemaSummariserService
{
    public string GetEfSummarizedSchema()
    {
        var builder = new StringBuilder();
        var entityTypes = context.Model.GetEntityTypes();

        foreach (var entityType in entityTypes)
        {
            var tableName = entityType.GetTableName();
            builder.AppendLine($"Table: {tableName}");

            AppendEfColumns(entityType, builder);

            AppendEfRelationships(entityType, builder);

            builder.AppendLine();
        }

        return builder.ToString();
    }

    private static void AppendEfRelationships(IEntityType entityType, StringBuilder builder)
    {
        foreach (var foreignKey in entityType.GetForeignKeys())
        {
            var principalTable = foreignKey.PrincipalEntityType.GetTableName();
            builder.AppendLine($"  Foreign Key: {foreignKey.DependentToPrincipal?.Name} -> {principalTable}");
        }
    }

    private static void AppendEfColumns(IEntityType entityType, StringBuilder builder)
    {
        foreach (var property in entityType.GetProperties())
        {
            builder.AppendLine($"  Column: {property.Name} ({property.ClrType.Name})");
        }
    }

    public async Task<string> GetSqlServerSummarizedSchemaAsync()
    {
        var connectionString = configuration.GetConnectionString("LateLearnerDevServer");
        await using var connection = new SqlConnection(connectionString);
        await connection.OpenAsync();

        var tables = await GetSqlServerTables(connection);

        var builder = new StringBuilder();
        foreach (var table in tables)
        {
            builder.AppendLine($"Table: {table}");

            await AppendSqlServerColumns(connection, table, builder);
            await AppendSqlServerForeignKeys(connection, table, builder);

            builder.AppendLine();
        }

        return builder.ToString();
    }

    private static async Task<List<string>> GetSqlServerTables(SqlConnection connection)
    {
        var tables = new List<string>();

        const string commandText = @"
        SELECT TABLE_NAME
        FROM INFORMATION_SCHEMA.TABLES
        WHERE TABLE_TYPE = 'BASE TABLE'
          AND TABLE_SCHEMA = 'dbo'     -- Skip EF migration tables
          AND TABLE_NAME NOT LIKE 'sys%'         -- Skip system tables
          AND TABLE_NAME NOT IN ('ErrorLog', 'BuildVersion', '__EFMigrationsHistory'); -- Skip known seed/sample tables
    ";

        await using var cmd = new SqlCommand(commandText, connection);
        await using var reader = await cmd.ExecuteReaderAsync();
        while (reader.Read())
        {
            tables.Add(reader.GetString(0));
        }

        return tables;
    }

    private static async Task AppendSqlServerColumns(SqlConnection connection, string tableName, StringBuilder builder)
    {
        const string commandText = @"
            SELECT COLUMN_NAME, DATA_TYPE
            FROM INFORMATION_SCHEMA.COLUMNS
            WHERE TABLE_NAME = @table;
        ";

        await using var cmd = new SqlCommand(commandText, connection);
        cmd.Parameters.AddWithValue("@table", tableName);

        await using var reader = await cmd.ExecuteReaderAsync();
        while (reader.Read())
        {
            builder.AppendLine($"  Column: {reader.GetString(0)} ({reader.GetString(1)})");
        }
    }

    private static async Task AppendSqlServerForeignKeys(SqlConnection connection, string tableName,
        StringBuilder builder)
    {
        const string commandText = @"
            SELECT 
                fk.name AS FK_Name,
                col.name AS FK_Column,
                ref.name AS Referenced_Table,
                ref_col.name AS Referenced_Column
            FROM 
                sys.foreign_keys fk
                INNER JOIN sys.foreign_key_columns fkc ON fk.object_id = fkc.constraint_object_id
                INNER JOIN sys.tables t ON fk.parent_object_id = t.object_id
                INNER JOIN sys.columns col ON fkc.parent_object_id = col.object_id AND fkc.parent_column_id = col.column_id
                INNER JOIN sys.tables ref ON fkc.referenced_object_id = ref.object_id
                INNER JOIN sys.columns ref_col ON fkc.referenced_object_id = ref_col.object_id AND fkc.referenced_column_id = ref_col.column_id
            WHERE t.name = @table;
        ";

        await using var cmd = new SqlCommand(commandText, connection);
        cmd.Parameters.AddWithValue("@table", tableName);

        await using var reader = await cmd.ExecuteReaderAsync();
        while (reader.Read())
        {
            var column = reader.GetString(1);
            var foreignTable = reader.GetString(2);
            var foreignColumn = reader.GetString(3);
            builder.AppendLine($"  Foreign Key: {column} -> {foreignTable}.{foreignColumn}");
        }
    }
}