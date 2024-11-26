using Application.Completions;
using Application.Completions.Dtos;
using Infrastructure.Extensions.Endpoints;

namespace API.Endpoints;

public class CompletionRequests :  IEndPointMapper
{
    public void MapEndpoints(IEndpointRouteBuilder endpointRouteBuilder)
    {
        endpointRouteBuilder.BuildPath("Completions")
            .MediatePost<CreateCompletionRequest, CompletionDto>("/");
    }
}