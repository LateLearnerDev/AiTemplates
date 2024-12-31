using Application.OpenAi.Completions;
using Application.OpenAi.Completions.Dtos;
using Infrastructure.Extensions.Endpoints;

namespace API.Endpoints.OpenAi;

public class CompletionRequests :  IEndPointMapper
{
    public void MapEndpoints(IEndpointRouteBuilder endpointRouteBuilder)
    {
        endpointRouteBuilder.BuildPath("Completions")
            .MediatePost<CreateCompletionRequest, CompletionDto>("/");
    }
}