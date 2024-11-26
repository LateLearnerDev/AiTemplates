using Application.Assistants.Dtos;
using Application.Assistants.Services;
using CommunityToolkit.Diagnostics;
using Infrastructure.Clients;

namespace Infrastructure.Services;

public class AssistantService(IOpenAiClient openAiClient) : IAssistantService
{
    public async Task<AssistantDto> CreateAssistantAsync(string name, string description, string instructions)
    {
        var assistant = await openAiClient.CreateAssistantAsync(name, description, instructions);
        Guard.IsNotNull(assistant);
        return new AssistantDto
        {
            Id = assistant.Id,
            Name = assistant.Name,
            Description = assistant.Description,
            Instructions = assistant.Instructions,
            CreatedAt = assistant.CreatedAt,
            Model = assistant.Model,
            ObjectType = assistant.Object,
            ResponseFormat = assistant.ResponseFormat,
            Tools = assistant.Tools.Select(tool => new Tool
            {
                Type = tool.Type
            }),
            Temperature = assistant.Temperature
        };
    }
}