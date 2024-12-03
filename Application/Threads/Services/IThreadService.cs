using Application.Threads.Dtos;
using Application.Threads.Pros;

namespace Application.Threads.Services;

public interface IThreadService
{
    Task<ThreadDto> CreateThreadAsync(List<ThreadMessagePro> messages);
    // Task<ThreadDto> UpdateThreadAsync();
    Task<ThreadDto> GetThreadAsync(string threadId);
}