using Application.AiTemplates.Dtos;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.AiTemplates;

public class GetEnglishToSqlValidationLogsRequest : IRequest<IEnumerable<EnglishToSqlValidationLogDto>>
{
    public DateTime? From { get; set; }
    public DateTime? To { get; set; }
    public bool? Success { get; set; }
    public int? MinTokenCost { get; set; }
    public int? MaxTokenCost { get; set; }
    public double? MinTimeTaken { get; set; }
    public double? MaxTimeTaken { get; set; }
    public string? ErrorType { get; set; }
}

public class GetEnglishToSqlValidationLogsRequestHandler(IRepository<EnglishToSqlValidationLog> repository)
    : IRequestHandler<GetEnglishToSqlValidationLogsRequest, IEnumerable<EnglishToSqlValidationLogDto>>
{
    public async Task<IEnumerable<EnglishToSqlValidationLogDto>> Handle(GetEnglishToSqlValidationLogsRequest request,
        CancellationToken cancellationToken)
    {
        var results = await repository.Query()
            .Where(x => !request.From.HasValue || x.Timestamp >= request.From.Value)
            .Where(x => !request.To.HasValue || x.Timestamp <= request.To.Value)
            .Where(x => !request.Success.HasValue || x.Success == request.Success.Value)
            .Where(x => !request.MinTokenCost.HasValue || x.TokenCost >= request.MinTokenCost.Value)
            .Where(x => !request.MaxTokenCost.HasValue || x.TokenCost <= request.MaxTokenCost.Value)
            .Where(x => !request.MinTimeTaken.HasValue || x.TimeTaken >= request.MinTimeTaken.Value)
            .Where(x => !request.MaxTimeTaken.HasValue || x.TimeTaken <= request.MaxTimeTaken.Value)
            .Where(x => string.IsNullOrWhiteSpace(request.ErrorType) || x.ErrorType == request.ErrorType)
            .OrderByDescending(x => x.Timestamp)
            .ToListAsync(cancellationToken: cancellationToken);
        
        return results.Select(EnglishToSqlValidationLogDto.From);
    }
}