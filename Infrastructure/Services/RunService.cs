using Application.OpenAi.Runs.Dtos;
using Application.OpenAi.Runs.Services;
using CommunityToolkit.Diagnostics;
using Infrastructure.Clients;
using Infrastructure.Clients.Models.OpenAi.Runs;

namespace Infrastructure.Services;

public class RunService(IOpenAiClient openAiClient) : IRunService
{
    public async Task<RunDto> CreateRunAsync(string threadId, string assistantId)
    {
        var run = await openAiClient.PostAsync<CreateRunRequestBody, Run>($"threads/{threadId}/runs",
            new CreateRunRequestBody
            {
                AssistantId = assistantId
            });
        Guard.IsNotNull(run);

        var finishedRun = await PollRunUntilCompletedAsync(run.Id, threadId);
        return finishedRun.ToDto();
    }
    
    private async Task<Run> PollRunUntilCompletedAsync(string runId, string threadId, int delayInSeconds = 2, int maxRetries = 30)
    {
        var retries = 0;
        while (retries < maxRetries)
        {
            var run = await openAiClient.GetAsync<Run>($"threads/{threadId}/runs/{runId}");
            Guard.IsNotNull(run);

            switch (run.Status)
            {
                case "completed":
                    return run;
                case "failed":
                case "cancelled":
                    throw new Exception($"Run failed or was cancelled. Status: {run.Status}, Error: {run.LastError}");
                default:
                    await Task.Delay(delayInSeconds * 1000);
                    retries++;
                    break;
            }
        }

        throw new TimeoutException("Run did not complete within the expected time.");
    }

    public Task<List<RunDto>> GetRunsAsync(string threadId)
    {
        throw new NotImplementedException();
    }

    public Task<RunDto> GetRunAsync(string threadId, string runId)
    {
        throw new NotImplementedException();
    }
}