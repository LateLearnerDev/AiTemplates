using Application.Services;
using MediatR;

namespace Application.Ai;

public class BasicInteractionRequest : IRequest<string>
{
    public required string Prompt { get; set; }
}

public class BasicInteractionRequestHandler(IOpenAiService service) : IRequestHandler<BasicInteractionRequest, string>
{
    public async Task<string> Handle(BasicInteractionRequest request, CancellationToken cancellationToken)
    {
        return await service.GenerateTextAsync(request.Prompt);
    }
}