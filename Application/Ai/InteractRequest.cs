using Application.Services;
using MediatR;

namespace Application.Ai;

public class InteractRequest : IRequest<string>
{
    public required string Prompt { get; set; }
}

public class InteractRequestHandler(IOpenAiService service) : IRequestHandler<InteractRequest, string>
{
    public async Task<string> Handle(InteractRequest request, CancellationToken cancellationToken)
    {
        return await service.GenerateTextAsync(request.Prompt);
    }
}