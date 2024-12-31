using Application.OpenAi.Assistants.Dtos;
using Application.OpenAi.Assistants.Services;
using MediatR;

namespace Application.OpenAi.Assistants;

public class GetAssistantRequest : IRequest<AssistantDto>
{
    public required string AssistantId { get; set; }
}

public class GetAssistantRequestHandler(IAssistantService assistantService) : IRequestHandler<GetAssistantRequest, AssistantDto>
{
    public async Task<AssistantDto> Handle(GetAssistantRequest request, CancellationToken cancellationToken)
    {
        var assistant = await assistantService.GetAssistantAsync(request.AssistantId);
        return assistant;
    }
}