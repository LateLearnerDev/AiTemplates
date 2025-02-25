using System.Dynamic;

namespace Application.QueryRunner;

public interface IQueryRunnerService
{
    Task<List<ExpandoObject>> RunSql(string sql);
    Task<(string ExexutionPlan, bool Success)> ValidateQuery(string sql);
}