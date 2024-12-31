using System.Text.Json.Serialization;

namespace Infrastructure.Clients.Models.OpenAi.Runs;

public class CreateRunRequestBody
{
    [JsonPropertyName("assistant_id")]
    public required string AssistantId { get; set; }
}