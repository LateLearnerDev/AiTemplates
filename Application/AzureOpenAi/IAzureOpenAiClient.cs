using OpenAI.Chat;

namespace Application.AzureOpenAi;

public interface IAzureOpenAiClient
{
    Task<ChatCompletion> GetChatCompletionAsync(string systemPrompt, string userPrompt, int maxTokens = 1000);
}