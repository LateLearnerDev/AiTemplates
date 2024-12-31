using Application.OpenAi.Messages.Dtos;
using Application.OpenAi.Messages.Services;
using CommunityToolkit.Diagnostics;
using Infrastructure.Clients;
using Infrastructure.Clients.Models.OpenAi.Messages;

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

    public async Task<MessageDto> UpdateMessageAsync(string threadId, string messageId, Dictionary<string, object> metadata)
    {
        var updatedMessage = await openAiClient.PostAsync<UpdateMessageRequestBody, Message>(
            $"threads/{threadId}/messages/{messageId}", new UpdateMessageRequestBody
            {
                MetaData = metadata
            });
        Guard.IsNotNull(updatedMessage);
        
        return updatedMessage.ToDto();
    }

    public async Task<List<MessageDto>> GetMessagesAsync(string threadId)
    {
        var messages = (await openAiClient.GetListAsync<Message>($"threads/{threadId}/messages"))?.ToList();
        Guard.IsNotNull(messages);
        
        return messages.Select(message => message.ToDto()).ToList();
    }

    public async Task<MessageDto> GetMessageAsync(string threadId, string messageId)
    {
        var message = await openAiClient.GetAsync<Message>($"threads/{threadId}/messages/{messageId}");
        Guard.IsNotNull(message);
        
        return message.ToDto();
    }
}