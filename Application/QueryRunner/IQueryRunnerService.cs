using System.Dynamic;

namespace Application.QueryRunner;

public interface IQueryRunnerService
{
    Task<List<ExpandoObject>> RunSqlAsync(string sql);
    Task<(string ExexutionPlan, bool Success)> ValidateQueryAsync(string sql);
}