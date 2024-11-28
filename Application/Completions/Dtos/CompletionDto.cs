namespace Application.Completions.Dtos;

public class CompletionDto
{
    public required string? Id { get; set; }
    public string? Object { get; set; }
    public long Created { get; set; }
    public string? Model { get; set; }
    public List<CompletionChoiceDto> Choices { get; set; } = [];
}

public class CompletionChoiceDto
{
    public int Index { get; set; }
    public CompletionMessageDto? Message { get; set; }
}

public class CompletionMessageDto
{
    public string? Role { get; set; }
    public string? Content { get; set; }
}