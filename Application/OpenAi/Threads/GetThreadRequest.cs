using Application.OpenAi.Threads.Dtos;
using Application.OpenAi.Threads.Services;
using MediatR;

namespace Application.OpenAi.Threads;

public class GetThreadRequest : IRequest<ThreadDto>
{
    public required string ThreadId { get; set; }
}

public class GetThreadRequestHandler(IThreadService threadService) : IRequestHandler<GetThreadRequest, ThreadDto>
{
    public async Task<ThreadDto> Handle(GetThreadRequest request, CancellationToken cancellationToken)
    {
        var thread = await threadService.GetThreadAsync(request.ThreadId);
        return thread; 
    }
}