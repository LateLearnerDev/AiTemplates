using Application.OpenAi.Completions.Dtos;
using Application.OpenAi.Completions.Exceptions;
using Application.OpenAi.Completions.Services;
using MediatR;

namespace Application.OpenAi.Completions;

public class CreateCompletionRequest : IRequest<CompletionDto>
{
    public required string SystemPrompt { get; set; }
    public required string UserPrompt { get; set; }
}

public class CreateCompletionRequestHandler(ICompletionService service) : IRequestHandler<CreateCompletionRequest, CompletionDto>
{
    public async Task<CompletionDto> Handle(CreateCompletionRequest request, CancellationToken cancellationToken)
    {
        var result = await service.CreateCompletionAsync(request.SystemPrompt, 
            request.UserPrompt);
        return result ?? throw new CompletionResponseNullException();
    }
}