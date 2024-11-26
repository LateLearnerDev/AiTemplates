using Newtonsoft.Json;

namespace Infrastructure.Clients.Models;

public class CompletionRequest
{
    [JsonProperty("model")]
    public string Model { get; set; } = "gpt-4o";
    
    [JsonProperty("messages")]
    public List<RequestMessage> Messages { get; set; }

    [JsonProperty("max_tokens")]
    public int MaxTokens { get; set; }
    
    [JsonProperty("temperature")]
    public decimal Temperature { get; set; }
    
    [JsonProperty("store")]
    public bool Store { get; set; }
}

public class RequestMessage
{
    [JsonProperty("role")]
    public string? Role { get; set; }

    [JsonProperty("content")]
    public string? Content { get; set; }
}