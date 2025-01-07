using System.Data;
using System.Dynamic;
using Application.EnglishToSql;
using Infrastructure.Storage.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class RawSqlService(AiTemplatesDbContext dbContext) : IRawSqlService
{
    public async Task<List<ExpandoObject>> RunSql(string sql)
    {
        var connection = dbContext.Database.GetDbConnection();

        using var command = connection.CreateCommand();
        command.CommandText = sql;

        if (connection.State != ConnectionState.Open)
        {
            await connection.OpenAsync();
        }

        using var reader = await command.ExecuteReaderAsync();
        var results = new List<ExpandoObject>();

        while (reader.Read())
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
}