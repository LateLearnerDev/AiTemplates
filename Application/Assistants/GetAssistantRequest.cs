using Application.Assistants.Dtos;
using Application.Assistants.Services;
using MediatR;

namespace Application.Assistants;

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