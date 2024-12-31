using System.Text.Json.Serialization;
using Application.OpenAi.Assistants.Dtos;

namespace Infrastructure.Clients.Models.OpenAi.Assistants;

public class Assistant
{
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("object")]
    public required string Object { get; set; }

    [JsonPropertyName("created_at")]
    public long CreatedAt { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }
 
    [JsonPropertyName("description")]
    public string? Description { get; set; }
 
    [JsonPropertyName("model")]
    public required string Model { get; set; }
 
    [JsonPropertyName("instructions")]
    public string? Instructions { get; set; }
 
    [JsonPropertyName("tools")]
    public IEnumerable<AssistantTool> Tools { get; set; } = [];
 
    [JsonPropertyName("metadata")]
    public Dictionary<string, string>? Metadata { get; set; }
 
    [JsonPropertyName("top_p")]
    public double TopP { get; set; }
 
    [JsonPropertyName("temperature")]
    public double Temperature { get; set; }
 
    [JsonPropertyName("response_format")]
    public object? ResponseFormat { get; set; }

    internal AssistantDto ToDto()
    {
        return new AssistantDto
        {
            Id = Id,
            Name = Name,
            Description = Description,
            Instructions = Instructions,
            CreatedAt = CreatedAt,
            Model = Model,
            ObjectType = Object,
            ResponseFormat = ResponseFormat,
            Tools = Tools.Select(tool => new AssistantToolDto
            {
                Type = tool.Type
            }),
            Temperature = Temperature
        };
    }
}

public class AssistantTool
{
    [JsonPropertyName("type")]
    public required string Type { get; set; }
}
