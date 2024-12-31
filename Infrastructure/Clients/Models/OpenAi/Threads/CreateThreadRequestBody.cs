using System.Text.Json.Serialization;

namespace Infrastructure.Clients.Models.OpenAi.Threads;

public class CreateThreadRequestBody
{
    [JsonPropertyName("messages")] public IEnumerable<ThreadMessageRequest> Messages { get; set; } = [];
}

public class ThreadMessageRequest
{
    [JsonPropertyName("role")] public required string Role { get; set; }
    [JsonPropertyName("content")] public required string Content { get; set; }
}