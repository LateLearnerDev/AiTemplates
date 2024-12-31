using System.Text.Json.Serialization;
using Application.OpenAi.Runs.Dtos;

namespace Infrastructure.Clients.Models.OpenAi.Runs;

public class Run
{
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("object")]
    public required string Object { get; set; }

    [JsonPropertyName("created_at")]
    public long CreatedAt { get; set; }

    [JsonPropertyName("assistant_id")]
    public required string AssistantId { get; set; }

    [JsonPropertyName("thread_id")]
    public required string ThreadId { get; set; }

    [JsonPropertyName("status")]
    public required string Status { get; set; }

    [JsonPropertyName("started_at")]
    public long? StartedAt { get; set; }

    [JsonPropertyName("expires_at")]
    public long? ExpiresAt { get; set; }

    [JsonPropertyName("cancelled_at")]
    public long? CancelledAt { get; set; }

    [JsonPropertyName("failed_at")]
    public long? FailedAt { get; set; }

    [JsonPropertyName("completed_at")]
    public long? CompletedAt { get; set; }

    [JsonPropertyName("last_error")]
    public string? LastError { get; set; }

    [JsonPropertyName("model")]
    public required string Model { get; set; }

    [JsonPropertyName("instructions")]
    public string? Instructions { get; set; }

    [JsonPropertyName("tools")]
    public List<RunTool> Tools { get; set; } = new();

    [JsonPropertyName("metadata")]
    public Dictionary<string, object> Metadata { get; set; } = new();

    [JsonPropertyName("incomplete_details")]
    public string? IncompleteDetails { get; set; }

    // [JsonPropertyName("usage")]
    // public RunUsage RunUsage { get; set; } = new();

    [JsonPropertyName("temperature")]
    public decimal Temperature { get; set; }

    [JsonPropertyName("top_p")]
    public decimal TopP { get; set; }

    [JsonPropertyName("max_prompt_tokens")]
    public int? MaxPromptTokens { get; set; }

    [JsonPropertyName("max_completion_tokens")]
    public int? MaxCompletionTokens { get; set; }

    [JsonPropertyName("truncation_strategy")]
    public TruncationStrategy? TruncationStrategy { get; set; } = new()
    {
        Type = ""
    };

    [JsonPropertyName("response_format")]
    public required string ResponseFormat { get; set; }

    [JsonPropertyName("tool_choice")]
    public required string ToolChoice { get; set; }

    [JsonPropertyName("parallel_tool_calls")]
    public bool ParallelToolCalls { get; set; }

    internal RunDto ToDto()
    {
        return new RunDto
        {
            Id = Id,
            Object = Object,
            CreatedAt = CreatedAt,
            AssistantId = AssistantId,
            ThreadId = ThreadId,
            Status = Status,
            StartedAt = StartedAt,
            ExpiresAt = ExpiresAt,
            CancelledAt = CancelledAt,
            Model = Model,
            ResponseFormat = ResponseFormat,
            ToolChoice = ToolChoice,
            ParallelToolCalls = ParallelToolCalls,
            Metadata = Metadata,
            TruncationStrategy = TruncationStrategy?.ToDto(),
            // Usage = RunUsage.ToDto(),
            Temperature = Temperature,
            TopP = TopP,
            MaxPromptTokens = MaxPromptTokens,
            MaxCompletionTokens = MaxCompletionTokens,
            IncompleteDetails = IncompleteDetails,
            LastError = LastError,
            Instructions = Instructions,
            Tools = Tools.Select(tool => tool.ToDto()).ToList(),
        };
    }
}

public class RunTool
{
    [JsonPropertyName("type")]
    public required string Type { get; set; }

    internal RunToolDto ToDto()
    {
        return new RunToolDto
        {
            Type = Type
        };
    }
}

// public class RunUsage
// {
//     [JsonPropertyName("prompt_tokens")]
//     public int PromptTokens { get; set; }
//
//     [JsonPropertyName("completion_tokens")]
//     public int CompletionTokens { get; set; }
//
//     [JsonPropertyName("total_tokens")]
//     public int TotalTokens { get; set; }
//
//     internal RunUsageDto ToDto()
//     {
//         return new RunUsageDto
//         {
//             PromptTokens = PromptTokens,
//             CompletionTokens = CompletionTokens,
//             TotalTokens = TotalTokens
//         };
//     }
// }

public class TruncationStrategy
{
    [JsonPropertyName("type")]
    public required string Type { get; set; }

    [JsonPropertyName("last_messages")]
    public string? LastMessages { get; set; }

    internal TruncationStrategyDto ToDto()
    {
        return new TruncationStrategyDto
        {
            Type = Type,
            LastMessages = LastMessages
        };
    }
}