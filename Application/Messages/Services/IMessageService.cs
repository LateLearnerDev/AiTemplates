using Application.Messages.Dtos;

namespace Application.Messages.Services;

public interface IMessageService
{
    Task<MessageDto> CreateMessageAsync(string threadId, string content, string role = "user");
    Task<MessageDto> UpdateMessageAsync(string threadId, string messageId, Dictionary<string, object> metadata);
    Task<List<MessageDto>> GetMessagesAsync(string threadId);
    Task<MessageDto> GetMessageAsync(string threadId, string messageId);
}