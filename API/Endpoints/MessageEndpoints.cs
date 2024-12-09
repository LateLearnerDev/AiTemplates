using Application.Messages;
using Application.Messages.Dtos;
using Infrastructure.Extensions.Endpoints;

namespace API.Endpoints;

public class MessageEndpoints : IEndPointMapper
{
    public void MapEndpoints(IEndpointRouteBuilder endpointRouteBuilder)
    {
        endpointRouteBuilder.BuildPath("Messages")
            .MediatePost<CreateMessageRequest, MessageDto>("/");
    }
}