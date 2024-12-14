using Application.Messages.Dtos;
using Application.Messages.Services;
using MediatR;

namespace Application.Messages;

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