using System.Data;
using System.Data.Common;
using System.Dynamic;
using System.Text;
using Application.Common.Extensions;
using Application.QueryRunner;
using Infrastructure.Storage.Persistence.Context;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class QueryRunnerService(AiTemplatesDbContext dbContext) : IQueryRunnerService
{
    public async Task<List<ExpandoObject>> ExecuteQueryAsync(string sql)
    {
        var connectionString = dbContext.Database.GetConnectionString();
        await using var connection = new SqlConnection(connectionString);
        await connection.OpenAsync();

        await using var command = connection.CreateCommand();
        command.CommandText = sql;

        return await FetchQueryResultsAsync(command);
    }

    public async Task<(string, bool)> ValidateQueryAsync(string sql)
    {
        if (!sql.StartsWith("SELECT", StringComparison.OrdinalIgnoreCase))
        {
            return ("Invalid Query: Only SELECT statements are allowed.", false);
        }
        
        await using var connection = dbContext.Database.GetDbConnection();
        await connection.OpenAsync();

        try
        {
            await EnableExecutionPlanModeAsync(connection);
            var executionPlan = await GetExecutionPlanAsync(connection, sql);
            
            return (executionPlan, true);
        }
        catch (Exception e)
        {
            return ($"Invalid SQL: {e.Message}", false);
        }
        finally
        {
            await DisableExecutionPlanModeAsync(connection);
            await connection.CloseAsync();
        }
    }
    
    private static async Task EnsureConnectionOpenAsync(DbConnection connection)
    {
        if (connection.State != ConnectionState.Open)
        {
            await connection.OpenAsync();
        }
    }
    
    private static async Task<List<ExpandoObject>> FetchQueryResultsAsync(DbCommand command)
    {
        var results = new List<ExpandoObject>();

        await using var reader = await command.ExecuteReaderAsync();
        while (await reader.ReadAsync())
        {
            var row = new ExpandoObject() as IDictionary<string, object>;
            for (var i = 0; i < reader.FieldCount; i++)
            {
                row[reader.GetName(i)] = reader.IsDBNull(i) ? null : reader.GetValue(i);
            }
            results.Add((ExpandoObject)row);
        }

        return results;
    }
    
    private static async Task EnableExecutionPlanModeAsync(DbConnection connection)
    {
        await using var command = connection.CreateCommand();
        command.CommandText = "SET SHOWPLAN_ALL ON";
        await command.ExecuteNonQueryAsync();
    }
    private static async Task DisableExecutionPlanModeAsync(DbConnection connection)
    {
        await using var command = connection.CreateCommand();
        command.CommandText = "SET SHOWPLAN_ALL OFF";
        await command.ExecuteNonQueryAsync();
    }
    
    private static async Task<string> GetExecutionPlanAsync(DbConnection connection, string cleanedQuery)
    {
        var planResult = new StringBuilder();

        await using var queryCommand = connection.CreateCommand();
        queryCommand.CommandText = cleanedQuery;

        await using var reader = await queryCommand.ExecuteReaderAsync();
        while (await reader.ReadAsync())
        {
            for (var i = 0; i < reader.FieldCount; i++)
            {
                planResult.Append($"{reader.GetName(i)}: {reader[i]?.ToString()} | ");
            }
            planResult.AppendLine();
        }

        return planResult.ToString();
    }
}