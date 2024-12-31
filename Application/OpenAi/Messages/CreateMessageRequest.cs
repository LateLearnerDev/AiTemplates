using Application.OpenAi.Messages.Dtos;
using Application.OpenAi.Messages.Services;
using MediatR;

namespace Application.OpenAi.Messages;

public class CreateMessageRequest : IRequest<MessageDto>
{
    public required string ThreadId { get; set; }
    public string Role { get; set; } = "user"; 
    public required string Content { get; set; }
}

public class CreateMessageRequestHandler(IMessageService messageService)
    : IRequestHandler<CreateMessageRequest, MessageDto>
{
    public Task<MessageDto> Handle(CreateMessageRequest request, CancellationToken cancellationToken)
    {
        var message = messageService.CreateMessageAsync(request.ThreadId, request.Content, request.Role);
        return message;
    }
}