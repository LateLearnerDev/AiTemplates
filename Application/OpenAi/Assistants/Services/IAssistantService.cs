using Application.OpenAi.Assistants.Dtos;

namespace Application.OpenAi.Assistants.Services;

public interface IAssistantService
{
    Task<AssistantDto> CreateAssistantAsync(string name, string description, string instructions);
    Task<AssistantDto> UpdateAssistantAsync(string assistantId, string name, string description, string instructions);
    Task<List<AssistantDto>> GetAssistantsAsync();
    Task<AssistantDto> GetAssistantAsync(string assistantId);
}