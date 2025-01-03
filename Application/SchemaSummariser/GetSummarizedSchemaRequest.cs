using Application.SchemaSummariser.Services;
using MediatR;

namespace Application.SchemaSummariser;

public class GetSummarizedSchemaRequest : IRequest<string>
{
    
}

public class GetSummarizedSchemaRequestHandler(ISchemaSummariserService service) : IRequestHandler<GetSummarizedSchemaRequest, string>
{
    public Task<string> Handle(GetSummarizedSchemaRequest request, CancellationToken cancellationToken)
    {
        return Task.FromResult(service.GetSummarizedSchema());
    }
}