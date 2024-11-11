using Application.Services;
using MediatR;

namespace Application.Ai;

public class GenerateQueryFromEnglishRequest : IRequest<string>
{
    public required string EnglishQuery { get; set; }
}

public class GenerateQueryFromEnglishRequestHandler(IOpenAiService openAiService) : IRequestHandler<GenerateQueryFromEnglishRequest, string>
{
    public Task<string> Handle(GenerateQueryFromEnglishRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}