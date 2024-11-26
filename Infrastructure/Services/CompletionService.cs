using Application.Completions.Dtos;
using Application.Completions.Services;
using CommunityToolkit.Diagnostics;
using Infrastructure.Clients;

namespace Infrastructure.Services;

public class CompletionService(IOpenAiClient openAiClient) : ICompletionService
{
    public async Task<CompletionDto?> CreateCompletionAsync(string systemPrompt, string userPrompt)
    {
        var response = await openAiClient.CreateCompletionAsync(systemPrompt, userPrompt);
        Guard.IsNotNull(response);
        return new CompletionDto
        {
            Id = response.Id,
            Object = response.Object,
            Created = response.Created,
            Model = response.Model,
            Choices = response.Choices.Select(c => new Choice
                {
                    Index = c.Index, Message = new Message
                    {
                        Role = c.Message?.Role,
                        Content = c.Message?.Content
                    }
                })
                .ToList()
        };
    }
}