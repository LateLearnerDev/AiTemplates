using Application.Assistants.Dtos;
using Application.Assistants.Services;
using CommunityToolkit.Diagnostics;
using Infrastructure.Clients;
using Infrastructure.Clients.Models;

namespace Infrastructure.Services;

public class AssistantService(IOpenAiClient openAiClient) : IAssistantService
{
    public async Task<AssistantDto> CreateAssistantAsync(string name, string description, string instructions)
    {
        var assistant = await openAiClient.PostAsync<CreateAssistantPro, Assistant>("assistants",
            new CreateAssistantPro
            {
                Name = name,
                Description = description,
                Instructions = instructions
            });
        Guard.IsNotNull(assistant);

        return assistant.ToDto();
    }
}