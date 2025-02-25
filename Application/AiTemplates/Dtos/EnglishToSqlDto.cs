namespace Application.AiTemplates.Dtos;

public class EnglishToSqlDto
{
    public required string Response { get; set; }
    public double TimeTaken { get; set; }
    public int TokenCost { get; set; }
    public bool Success { get; set; }
    public string? ValidationMessage { get; set; }
}