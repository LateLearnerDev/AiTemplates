using Application.OpenAi.Threads.Dtos;
using Application.OpenAi.Threads.Pros;
using Application.OpenAi.Threads.Services;
using CommunityToolkit.Diagnostics;
using Infrastructure.Clients;
using Infrastructure.Clients.Models.OpenAi.Threads;
using Thread = Infrastructure.Clients.Models.OpenAi.Threads.Thread;

namespace Infrastructure.Services;

public class ThreadService(IOpenAiClient openAiClient) : IThreadService
{
    public async Task<ThreadDto> CreateThreadAsync(List<ThreadMessagePro> messages)
    {
        var thread = await openAiClient.PostAsync<CreateThreadRequestBody, Thread>("threads",
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
        var thread = await openAiClient.GetAsync<Thread>("threads/" + threadId);
        Guard.IsNotNull(thread);
        
        return thread.ToDto();
    }
}