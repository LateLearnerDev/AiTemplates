using Application.SchemaSummariser;
using Infrastructure.Extensions.Endpoints;

namespace API.Endpoints;

public class SchemaSummariserEndpoints : IEndPointMapper
{
    public void MapEndpoints(IEndpointRouteBuilder endpointRouteBuilder)
    {
        endpointRouteBuilder.BuildPath("SchemaSummariser")
            .MediateGet<GetSummarizedSchemaRequest, string>("/");
    }
}