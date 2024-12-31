using System.Text.Json.Serialization;
using Application.OpenAi.Threads.Dtos;

namespace Infrastructure.Clients.Models.OpenAi.Threads;

public class Thread
{
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("object")]
    public required string Object { get; set; }

    [JsonPropertyName("created_at")]
    public long CreatedAt { get; set; }

    [JsonPropertyName("metadata")]
    public Dictionary<string, object> Metadata { get; set; } = new Dictionary<string, object>();

    [JsonPropertyName("tool_resources")]
    public Dictionary<string, object> ToolResources { get; set; } = new Dictionary<string, object>();

    internal ThreadDto ToDto()
    {
        return new ThreadDto
        {
            Id = Id,
            Object = Object,
            CreatedAt = CreatedAt,
            Metadata = Metadata,
            ToolResources = ToolResources
        };
    }
}