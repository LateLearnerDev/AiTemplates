using Application.OpenAi.Threads.Dtos;
using Application.OpenAi.Threads.Pros;
using Application.OpenAi.Threads.Services;
using MediatR;

namespace Application.OpenAi.Threads;

public class CreateThreadRequest : IRequest<ThreadDto>
{
    public List<ThreadMessagePro> ThreadMessages { get; set; } = [];
}

public class CreateThreadRequestHandler(IThreadService threadService) : IRequestHandler<CreateThreadRequest, ThreadDto>
{
    public async Task<ThreadDto> Handle(CreateThreadRequest request, CancellationToken cancellationToken)
    {
        var thread = await threadService.CreateThreadAsync(request.ThreadMessages);
        return thread; 
    }
}