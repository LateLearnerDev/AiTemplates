using Application.Messages.Dtos;

namespace Application.Messages.Services;

public interface IMessageService
{
    Task<MessageDto> CreateMessageAsync(string threadId, string content, string role = "user");
    Task<MessageDto> UpdateAssistantAsync(string threadId, string messageId, List<KeyValuePair<string, string>> metadata);
    Task<List<MessageDto>> GetMessagesAsync(string threadId);
    Task<MessageDto> GetMessageAsync(string threadId, string messageId);
}