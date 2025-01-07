using System.Dynamic;

namespace Application.EnglishToSql;

public interface IRawSqlService
{
    Task<List<ExpandoObject>> RunSql(string sql);
}