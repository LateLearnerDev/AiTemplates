namespace Application.OpenAi.Runs.Dtos;

public class RunDto
{
    public required string Id { get; set; }
    public required string Object { get; set; }
    public long CreatedAt { get; set; }
    public required string AssistantId { get; set; }
    public required string ThreadId { get; set; }
    public required string Status { get; set; }
    public long? StartedAt { get; set; }
    public long? ExpiresAt { get; set; }
    public long? CancelledAt { get; set; }
    public long? FailedAt { get; set; }
    public long? CompletedAt { get; set; }
    public string? LastError { get; set; }
    public required string Model { get; set; }
    public string? Instructions { get; set; }
    public List<RunToolDto> Tools { get; set; } = new();
    public Dictionary<string, object> Metadata { get; set; } = new();
    public string? IncompleteDetails { get; set; }
    public RunUsageDto Usage { get; set; } = new();
    public decimal Temperature { get; set; }
    public decimal TopP { get; set; }
    public int? MaxPromptTokens { get; set; }
    public int? MaxCompletionTokens { get; set; }
    public TruncationStrategyDto? TruncationStrategy { get; set; } = new()
    {
        Type = ""
    };
    public required string ResponseFormat { get; set; }
    public required string ToolChoice { get; set; }
    public bool ParallelToolCalls { get; set; }
}

public class RunToolDto
{
    public required string Type { get; set; }
}

public class RunUsageDto
{
    public int PromptTokens { get; set; }
    public int CompletionTokens { get; set; }
    public int TotalTokens { get; set; }
}

public class TruncationStrategyDto
{
    public required string Type { get; set; }
    public string? LastMessages { get; set; }
}