using System.Text.Json.Serialization;

namespace Infrastructure.Clients.Models.Pros;

public class UpdateAssistantPro
{
    [JsonPropertyName("name")] public required string Name { get; set; }

    [JsonPropertyName("description")] public required string Description { get; set; }

    [JsonPropertyName("instructions")] public required string Instructions { get; set; }
}