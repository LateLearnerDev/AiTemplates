using Application.Assistants.Dtos;
using Application.Assistants.Services;
using CommunityToolkit.Diagnostics;
using Infrastructure.Clients;
using Infrastructure.Clients.Models;
using Infrastructure.Clients.Models.Pros;
using Infrastructure.Clients.Models.Responses;

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

    public async Task<AssistantDto> UpdateAssistantAsync(string assistantId, string name, string description, string instructions)
    {
        var assistant = await openAiClient.PostAsync<UpdateAssistantPro, Assistant>("assistants/" + assistantId,
            new UpdateAssistantPro
            {
                Name = name,
                Description = description,
                Instructions = instructions
            });
        Guard.IsNotNull(assistant);

        return assistant.ToDto();
    }

    public async Task<List<AssistantDto>> GetAssistantsAsync()
    {
        var assistants = (await openAiClient.GetListAsync<Assistant>("assistants"))?
            .ToList();
        Guard.IsNotNull(assistants);
        return assistants.Select(x => x.ToDto()).ToList();
    }

    public async Task<AssistantDto> GetAssistantAsync(string assistantId)
    {
        var assistant = await openAiClient.GetAsync<Assistant>("assistants/" + assistantId);
        Guard.IsNotNull(assistant);
        return assistant.ToDto();
    }
}