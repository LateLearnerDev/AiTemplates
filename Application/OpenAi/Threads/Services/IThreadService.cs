using Application.OpenAi.Threads.Dtos;
using Application.OpenAi.Threads.Pros;

namespace Application.OpenAi.Threads.Services;

public interface IThreadService
{
    Task<ThreadDto> CreateThreadAsync(List<ThreadMessagePro> messages);
    // Task<ThreadDto> UpdateThreadAsync();
    Task<ThreadDto> GetThreadAsync(string threadId);
}