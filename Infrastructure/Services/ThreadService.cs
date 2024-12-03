using Application.Threads.Dtos;
using Application.Threads.Pros;
using Application.Threads.Services;
using CommunityToolkit.Diagnostics;
using Infrastructure.Clients;
using Infrastructure.Clients.Models.RequestBodies;

namespace Infrastructure.Services;

public class ThreadService(IOpenAiClient openAiClient) : IThreadService
{
    public async Task<ThreadDto> CreateThreadAsync(List<ThreadMessagePro> messages)
    {
        var thread = await openAiClient.PostAsync<CreateThreadRequestBody, Infrastructure.Clients.Models.Responses.Thread>("threads",
            new CreateThreadRequestBody
            {
                Messages = messages.Select(message => new ThreadMessageRequest
                {
                    Content = message.Content,
                    Role = message.Role
                })
            });
        Guard.IsNotNull(thread);

        return thread.ToDto();
    }

    public async Task<ThreadDto> GetThreadAsync(string threadId)
    {
        var thread = await openAiClient.GetAsync<Infrastructure.Clients.Models.Responses.Thread>("threads/" + threadId);
        Guard.IsNotNull(thread);
        
        return thread.ToDto();
    }
}