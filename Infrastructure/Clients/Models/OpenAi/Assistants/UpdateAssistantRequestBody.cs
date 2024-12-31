using System.Text.Json.Serialization;

namespace Infrastructure.Clients.Models.OpenAi.Assistants;

public class UpdateAssistantRequestBody
{
    [JsonPropertyName("name")] public required string Name { get; set; }

    [JsonPropertyName("description")] public required string Description { get; set; }

    [JsonPropertyName("instructions")] public required string Instructions { get; set; }
}