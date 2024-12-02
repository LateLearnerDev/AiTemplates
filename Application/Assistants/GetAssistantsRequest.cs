using Application.Assistants.Dtos;
using Application.Assistants.Services;
using MediatR;

namespace Application.Assistants;

public class GetAssistantsRequest : IRequest<IEnumerable<AssistantDto>>
{
    
}

public class GetAssistantsRequestHandler(IAssistantService assistantService) : IRequestHandler<GetAssistantsRequest, IEnumerable<AssistantDto>>
{
    public async Task<IEnumerable<AssistantDto>> Handle(GetAssistantsRequest request, CancellationToken cancellationToken)
    {
        var assistants = await assistantService.GetAssistantsAsync();
        return assistants;
    }
}