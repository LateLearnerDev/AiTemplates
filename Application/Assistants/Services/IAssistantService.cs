using Application.Assistants.Dtos;

namespace Application.Assistants.Services;

public interface IAssistantService
{
    Task<AssistantDto> CreateAssistantAsync(string name, string description, string instructions);
}