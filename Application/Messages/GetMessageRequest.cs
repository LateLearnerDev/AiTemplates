using Application.Messages.Dtos;
using Application.Messages.Services;
using MediatR;

namespace Application.Messages;

public class GetMessageRequest : IRequest<MessageDto>
{
    public required string ThreadId { get; set; }
    public required string MessageId { get; set; }
}

public class GetMessageRequestHandler(IMessageService messageService) : IRequestHandler<GetMessageRequest, MessageDto>
{
    public async Task<MessageDto> Handle(GetMessageRequest request, CancellationToken cancellationToken)
    {
        var message = await messageService.GetMessageAsync(request.ThreadId, request.MessageId);
        return message;
    }
}