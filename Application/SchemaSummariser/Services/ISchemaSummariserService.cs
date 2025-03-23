namespace Application.SchemaSummariser.Services;

public interface ISchemaSummariserService
{
    string GetEfSummarizedSchema();
    Task<string> GetSqlServerSummarizedSchemaAsync();
}