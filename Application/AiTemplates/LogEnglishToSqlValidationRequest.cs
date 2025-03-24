using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.AiTemplates;

public class LogEnglishToSqlValidationRequest : IRequest<bool>
{
    public required string UserRequest { get; set; }
    public required string AiResponse { get; set; }
    public required bool Success { get; set; }
    public required int TokenCost { get; set; }
    public required double TimeTaken { get; set; }
    public string? ErrorMessage { get; set; }
    public string? ErrorType { get; set; }
}

public class LogEnglishToSqlValidationRequestHandler(IRepository<EnglishToSqlValidationLog> repository) : IRequestHandler<LogEnglishToSqlValidationRequest, bool>
{
    public async Task<bool> Handle(LogEnglishToSqlValidationRequest request, CancellationToken cancellationToken)
    {
        await repository
            .AddAsync(EnglishToSqlValidationLog.Create(
                request.UserRequest,
                request.AiResponse,
                request.Success,
                request.TokenCost,
                request.TimeTaken,
                request.ErrorMessage,
                request.ErrorType

            ));
        
        return true;
    }
}