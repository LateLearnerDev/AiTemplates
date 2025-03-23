using System.ClientModel;
using Application.AzureOpenAi;
using Azure.AI.OpenAI;
using Microsoft.Extensions.Configuration;
using OpenAI.Chat;

namespace Infrastructure.Clients;

public class AzureOpenAiClient : IAzureOpenAiClient
{
    private readonly AzureOpenAIClient _azureOpenAiClient;

    public AzureOpenAiClient(IConfiguration configuration)
    {
        var endpoint = configuration["AzureOpenAiBaseEndpoint"];
        var key = configuration["AzureOpenAiApiKey"];
        _azureOpenAiClient = new AzureOpenAIClient(new Uri(endpoint!), new ApiKeyCredential(key!));
    }

    public async Task<ChatCompletion> GetChatCompletionAsync(string systemPrompt, string userPrompt, int maxTokens = 1000)
    {
        var completionClient = _azureOpenAiClient.GetChatClient("gpt-4o-mini");

        var chatMessages = new List<ChatMessage>
        {
            ChatMessage.CreateSystemMessage(systemPrompt),
            ChatMessage.CreateUserMessage(userPrompt),
        };

        var response = await completionClient.CompleteChatAsync(chatMessages, new ChatCompletionOptions
        {
            Temperature = 0.3f,
            MaxOutputTokenCount = maxTokens
        });

        return response.Value;
    }
}