using Application.Completions.Dtos;
using Application.Completions.Services;
using CommunityToolkit.Diagnostics;
using Infrastructure.Clients;
using Infrastructure.Clients.Models;

namespace Infrastructure.Services;

public class CompletionService(IOpenAiClient openAiClient) : ICompletionService
{
    public async Task<CompletionDto?> CreateCompletionAsync(string systemPrompt, string userPrompt)
    {
        var systemMessage = new CompletionProMessage { Role = "system", Content = systemPrompt };
        var userMessage = new CompletionProMessage { Role = "user", Content = userPrompt };
        var request = new CreateCompletionPro
        {
            Model = "gpt-4o",
            Messages = [systemMessage, userMessage],
            MaxTokens = 100,
            Temperature = 0.7m,
            Store = true
        };
        
        var response = await openAiClient.PostAsync<CreateCompletionPro, Completion>("chat/completions", request);
        Guard.IsNotNull(response);

        return response.ToDto();
    }
}