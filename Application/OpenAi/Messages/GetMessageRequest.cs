using Application.OpenAi.Messages.Dtos;
using Application.OpenAi.Messages.Services;
using MediatR;

namespace Application.OpenAi.Messages;

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