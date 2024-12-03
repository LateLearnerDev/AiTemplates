using System.Text.Json.Serialization;

namespace Infrastructure.Clients.Models.RequestBodies;

public class CreateCompletionRequestBody
{
    [JsonPropertyName("model")] public string Model { get; set; } = "gpt-4o";

    [JsonPropertyName("messages")] public List<CompletionRequestMessage> Messages { get; set; }

    [JsonPropertyName("max_tokens")] public int MaxTokens { get; set; }

    [JsonPropertyName("temperature")] public decimal Temperature { get; set; }

    [JsonPropertyName("store")] public bool Store { get; set; }
}

public class CompletionRequestMessage
{
    [JsonPropertyName("role")] public string? Role { get; set; }

    [JsonPropertyName("content")] public string? Content { get; set; }
}