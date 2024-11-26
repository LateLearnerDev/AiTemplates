using Application.Assistants;
using Application.Assistants.Dtos;
using Infrastructure.Extensions.Endpoints;

namespace API.Endpoints;

public class AssistantRequests :  IEndPointMapper
{
    public void MapEndpoints(IEndpointRouteBuilder endpointRouteBuilder)
    {
        endpointRouteBuilder.BuildPath("Assistants")
            .MediatePost<CreateAssistantRequest, AssistantDto>("/");
    }
}