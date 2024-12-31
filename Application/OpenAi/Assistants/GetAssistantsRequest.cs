using Application.OpenAi.Assistants.Dtos;
using Application.OpenAi.Assistants.Services;
using MediatR;

namespace Application.OpenAi.Assistants;

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