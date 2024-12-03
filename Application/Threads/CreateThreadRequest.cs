using Application.Threads.Dtos;
using Application.Threads.Pros;
using Application.Threads.Services;
using MediatR;

namespace Application.Threads;

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