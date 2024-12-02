using Application.Assistants;
using Application.Assistants.Dtos;
using Infrastructure.Extensions.Endpoints;

namespace API.Endpoints;

public class AssistantRequests :  IEndPointMapper
{
    public void MapEndpoints(IEndpointRouteBuilder endpointRouteBuilder)
    {
        endpointRouteBuilder.BuildPath("Assistants")
            .MediateGet<GetAssistantsRequest, IEnumerable<AssistantDto>>("/")
            .MediateGet<GetAssistantRequest, AssistantDto>("/{assistantId}")
            .MediatePost<CreateAssistantRequest, AssistantDto>("/")
            .MediatePut<UpdateAssistantRequest, AssistantDto>("/{assistantId}");
    }
}