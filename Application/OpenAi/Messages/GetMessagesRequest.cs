using Application.OpenAi.Messages.Dtos;
using Application.OpenAi.Messages.Services;
using MediatR;

namespace Application.OpenAi.Messages;

public class GetMessagesRequest : IRequest<List<MessageDto>>
{
    public required string ThreadId { get; set; }
}

public class GetMessagesRequestHandler(IMessageService messageService) : IRequestHandler<GetMessagesRequest, List<MessageDto>>
{
    public async Task<List<MessageDto>> Handle(GetMessagesRequest request, CancellationToken cancellationToken)
    {
        var messages = await messageService.GetMessagesAsync(request.ThreadId);
        return messages;
    }
}