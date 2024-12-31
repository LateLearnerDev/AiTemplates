using Application.OpenAi.Assistants.Dtos;
using Application.OpenAi.Assistants.Services;
using MediatR;

namespace Application.OpenAi.Assistants;

public class CreateAssistantRequest : IRequest<AssistantDto>
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required string Instructions { get; set; }
}

public class CreateAssistantRequestHandler(IAssistantService service) : IRequestHandler<CreateAssistantRequest, AssistantDto>
{
    public async Task<AssistantDto> Handle(CreateAssistantRequest request, CancellationToken cancellationToken)
    {
        var result = await service.CreateAssistantAsync(request.Name, request.Description, request.Instructions);
        return result;
    }
}