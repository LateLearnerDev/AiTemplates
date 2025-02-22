namespace Application.AiTemplates.Dtos;

public class EnglishToSqlDto
{
    public required string Response { get; set; }
    public float TimeTaken { get; set; }
    public int TokenCost { get; set; }
}