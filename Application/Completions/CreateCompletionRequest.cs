using Application.Completions.Dtos;
using Application.Completions.Exceptions;
using Application.Completions.Services;
using MediatR;

namespace Application.Completions;

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