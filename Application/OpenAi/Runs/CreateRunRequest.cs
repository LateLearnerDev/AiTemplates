using Application.OpenAi.Runs.Dtos;
using Application.OpenAi.Runs.Services;
using MediatR;

namespace Application.OpenAi.Runs;

public class CreateRunRequest : IRequest<RunDto>
{
    public required string ThreadId { get; set; }
    public required string AssistantId { get; set; }
}

public class CreateRunRequestHandler(IRunService runService) : IRequestHandler<CreateRunRequest, RunDto>
{
    public async Task<RunDto> Handle(CreateRunRequest request, CancellationToken cancellationToken)
    {
        var run = await runService.CreateRunAsync(request.ThreadId, request.AssistantId);
        return run;
    }
}