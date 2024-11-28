using Newtonsoft.Json;

namespace Infrastructure.Clients.Models;

public class Assistant
{
    [JsonProperty("id")]
    public required string Id { get; set; }

    [JsonProperty("object")]
    public required string Object { get; set; }

    [JsonProperty("created_at")]
    public long CreatedAt { get; set; }

    [JsonProperty("name")]
    public string? Name { get; set; }
 
    [JsonProperty("description")]
    public string? Description { get; set; }
 
    [JsonProperty("model")]
    public required string Model { get; set; }
 
    [JsonProperty("instructions")]
    public string? Instructions { get; set; }
 
    [JsonProperty("tools")]
    public IEnumerable<Tool> Tools { get; set; } = [];
 
    [JsonProperty("metadata")]
    public Dictionary<string, string>? Metadata { get; set; }
 
    [JsonProperty("top_p")]
    public double TopP { get; set; }
 
    [JsonProperty("temperature")]
    public double Temperature { get; set; }
 
    [JsonProperty("response_format")]
    public object? ResponseFormat { get; set; }
}

public class Tool
{
    [JsonProperty("type")]
    public required string Type { get; set; }
}
