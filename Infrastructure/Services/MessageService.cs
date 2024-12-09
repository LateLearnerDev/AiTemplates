using Application.Messages.Dtos;
using Application.Messages.Services;
using CommunityToolkit.Diagnostics;
using Infrastructure.Clients;
using Infrastructure.Clients.Models.RequestBodies;
using Infrastructure.Clients.Models.Responses;

namespace Infrastructure.Services;

public class MessageService(IOpenAiClient openAiClient) : IMessageService
{
    public async Task<MessageDto> CreateMessageAsync(string threadId, string content, string role)
    {
        var message = await openAiClient.PostAsync<CreateMessageRequestBody, Message>($"threads/{threadId}/messages",
            new CreateMessageRequestBody
            {
                Content = content,
                Role = role
            });
        Guard.IsNotNull(message);

        return message.ToDto();
    }

    public Task<MessageDto> UpdateAssistantAsync(string threadId, string messageId, List<KeyValuePair<string, string>> metadata)
    {
        throw new NotImplementedException();
    }

    public Task<List<MessageDto>> GetMessagesAsync(string threadId)
    {
        throw new NotImplementedException();
    }

    public Task<MessageDto> GetMessageAsync(string threadId, string messageId)
    {
        throw new NotImplementedException();
    }
}