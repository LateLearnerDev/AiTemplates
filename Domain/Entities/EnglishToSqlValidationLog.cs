namespace Domain.Entities;

public class EnglishToSqlValidationLog : Entity
{
    public required string UserRequest { get; set; }
    public required string AiResponse { get; set; }
    public required bool Success { get; set; }
    public required int TokenCost { get; set; }
    public required double TimeTaken { get; set; }
    public string? ErrorMessage { get; set; }
    public string? ErrorType { get; set; }
    public required DateTime Timestamp { get; set; }

    public static EnglishToSqlValidationLog Create(string userRequest, string aiResponse, bool success, int tokenCost,
        double timeTaken, string? errorMessage, string? errorType)
    {
        return new EnglishToSqlValidationLog
        {
            UserRequest = userRequest,
            AiResponse = aiResponse,
            Success = success,
            TokenCost = tokenCost,
            TimeTaken = timeTaken,
            ErrorMessage = errorMessage,
            ErrorType = errorType,
            Timestamp = DateTime.UtcNow,
        };
    }
}