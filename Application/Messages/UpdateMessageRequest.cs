using Application.Messages.Dtos;
using Application.Messages.Services;
using MediatR;

namespace Application.Messages;

public class UpdateMessageRequest : IRequest<MessageDto>
{
    public required string ThreadId { get; set; }
    public required string MessageId { get; set; }
    public required Dictionary<string, object> Metadata { get; set; } 
}

public class UpdateMessageRequestHandler(IMessageService messageService) : IRequestHandler<UpdateMessageRequest, MessageDto>
{
    public async Task<MessageDto> Handle(UpdateMessageRequest request, CancellationToken cancellationToken)
    {
        var updatedMessage = await messageService.UpdateMessageAsync(request.ThreadId, request.MessageId, request.Metadata);
        return updatedMessage;
    }
}