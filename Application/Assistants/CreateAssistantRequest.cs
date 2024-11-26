using Application.Assistants.Dtos;
using Application.Assistants.Services;
using Application.Completions;
using Application.Completions.Dtos;
using Application.Completions.Exceptions;
using Application.Completions.Services;
using MediatR;

namespace Application.Assistants;

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
        return result ?? throw new CompletionResponseNullException();
    }
}