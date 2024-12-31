using Application.OpenAi.Runs.Dtos;

namespace Application.OpenAi.Runs.Services;

public interface IRunService
{
    Task<RunDto> CreateRunAsync(string threadId, string assistantId);
    Task<List<RunDto>> GetRunsAsync(string threadId);
    Task<RunDto> GetRunAsync(string threadId, string runId);
}