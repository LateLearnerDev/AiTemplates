using Infrastructure.Clients.Models;

namespace Infrastructure.Clients;

public interface IOpenAiClient
{
    Task<Assistant?> CreateAssistantAsync(string name, string description, string instructions);
    Task<Completion?> CreateCompletionAsync(string systemPrompt, string userPrompt);
}