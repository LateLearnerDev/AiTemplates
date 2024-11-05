using Application.Ai;
using Infrastructure.Extensions.Endpoints;

namespace API.Endpoints;

public class AiRequests :  IEndPointMapper
{
    public void MapEndpoints(IEndpointRouteBuilder endpointRouteBuilder)
    {
        endpointRouteBuilder.BuildPath("Ai")
            .MediatePost<InteractRequest, string>("/");
    }
}