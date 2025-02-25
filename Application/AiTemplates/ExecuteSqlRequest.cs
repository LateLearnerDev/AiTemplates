using System.Dynamic;
using Application.QueryRunner;
using MediatR;

namespace Application.AiTemplates;

public class ExecuteSqlRequest : IRequest<List<ExpandoObject>>
{
    public required string SqlQuery { get; set; }
}

public class ExecuteSqlRequestHandler(IQueryRunnerService queryRunnerService) : IRequestHandler<ExecuteSqlRequest, List<ExpandoObject>>
{
    public async Task<List<ExpandoObject>> Handle(ExecuteSqlRequest request, CancellationToken cancellationToken)
    {
        return await queryRunnerService.RunSqlAsync(request.SqlQuery);
    }
}