using Domain.Entities;

namespace Application.AiTemplates.Dtos;

public class EnglishToSqlValidationLogDto 
{
    public required string UserRequest { get; set; }
    public required string AiResponse { get; set; }
    public required bool Success { get; set; }
    public required int TokenCost { get; set; }
    public required double TimeTaken { get; set; }
    public string? ErrorMessage { get; set; }
    public string? ErrorType { get; set; }
    public required DateTime Timestamp { get; set; }

    public static EnglishToSqlValidationLogDto From(EnglishToSqlValidationLog log)
    {
        return new EnglishToSqlValidationLogDto
        {
            UserRequest = log.UserRequest,
            AiResponse = log.AiResponse,
            Success = log.Success,
            TokenCost = log.TokenCost,
            TimeTaken = log.TimeTaken,
            ErrorMessage = log.ErrorMessage,
            ErrorType = log.ErrorType,
            Timestamp = log.Timestamp,
        };
    }
}