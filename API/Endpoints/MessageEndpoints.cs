using Application.Messages;
using Application.Messages.Dtos;
using Infrastructure.Extensions.Endpoints;

namespace API.Endpoints;

public class MessageEndpoints : IEndPointMapper
{
    public void MapEndpoints(IEndpointRouteBuilder endpointRouteBuilder)
    {
        endpointRouteBuilder.BuildPath("Messages")
            .MediatePost<CreateMessageRequest, MessageDto>("/")
            .MediateGet<GetMessageRequest, MessageDto>("/{threadId}/{messageId}")
            .MediateGet<GetMessagesRequest, List<MessageDto>>("/{threadId}");
        // .MediatePut<UpdateMessageRequest, MessageDto>("/{threadId}/{messageId}") - This isn't needed. Updating a message only updates metadata which is a complicated object
    }
}