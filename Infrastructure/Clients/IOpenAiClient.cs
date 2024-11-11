namespace Infrastructure.Clients;

public interface IOpenAiClient
{
    Task<string> SendBasicSinglePromptResponseAsync(string prompt);
    Task<string> SendCustomPromptResponseAsync(string userPrompt, string systemPrompt);
}