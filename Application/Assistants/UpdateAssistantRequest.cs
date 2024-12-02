using Application.Assistants.Dtos;
using Application.Assistants.Services;
using Application.Completions.Exceptions;
using MediatR;

namespace Application.Assistants;

public class UpdateAssistantRequest : IRequest<AssistantDto>
{
    public required string AssistantId { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required string Instructions { get; set; }
}

public class UpdateAssistantRequestRequestHandler(IAssistantService service)
    : IRequestHandler<UpdateAssistantRequest, AssistantDto>
{
    public async Task<AssistantDto> Handle(UpdateAssistantRequest request, CancellationToken cancellationToken)
    {
        var result = await service.UpdateAssistantAsync(
            request.AssistantId,
            request.Name,
            request.Description,
            request.Instructions);
        return result;
    }
}