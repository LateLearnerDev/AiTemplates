using Application.OpenAi.Runs;
using Application.OpenAi.Runs.Dtos;
using Infrastructure.Extensions.Endpoints;

namespace API.Endpoints.OpenAi;

public class RunEndpoints : IEndPointMapper
{
    public void MapEndpoints(IEndpointRouteBuilder endpointRouteBuilder)
    {
        endpointRouteBuilder.BuildPath("Run")
            .MediatePost<CreateRunRequest, RunDto>("/");
    }
}