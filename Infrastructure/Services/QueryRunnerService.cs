using System.Data;
using System.Dynamic;
using System.Text;
using Application.Common.Extensions;
using Application.QueryRunner;
using Infrastructure.Storage.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class QueryRunnerService(AiTemplatesDbContext dbContext) : IQueryRunnerService
{
    public async Task<List<ExpandoObject>> RunSql(string sql)
    {
        var connection = dbContext.Database.GetDbConnection();

        await using var command = connection.CreateCommand();
        command.CommandText = sql;

        if (connection.State != ConnectionState.Open)
        {
            await connection.OpenAsync();
        }

        await using var reader = await command.ExecuteReaderAsync();
        var results = new List<ExpandoObject>();

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

    public async Task<(string, bool)> ValidateQuery(string sql)
    {
        var planResult = new StringBuilder();
        var queryOnly = sql.RemoveMarkdownNewLinesAndSpaces();

        await using var connection = dbContext.Database.GetDbConnection();
        await connection.OpenAsync();

        try
        {
            await using var enableShowPlanCommand = connection.CreateCommand();
            enableShowPlanCommand.CommandText = "SET SHOWPLAN_ALL ON";
            await enableShowPlanCommand.ExecuteNonQueryAsync(); 

            await using var queryCommand = connection.CreateCommand();
            queryCommand.CommandText = queryOnly;

            await using var reader = await queryCommand.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                for (var i = 0; i < reader.FieldCount; i++)
                {
                    planResult.Append($"{reader.GetName(i)}: {reader[i].ToString()} | ");
                }
                planResult.AppendLine();
            }

            return (planResult.ToString(), true);
        }
        catch (Exception e)
        {
            return ($"Invalid SQL: {e.Message}", false);
        }
        finally
        {
            await using var disableShowPlanCommand = connection.CreateCommand();
            disableShowPlanCommand.CommandText = "SET SHOWPLAN_ALL OFF";
            await disableShowPlanCommand.ExecuteNonQueryAsync();
        }
    }
}