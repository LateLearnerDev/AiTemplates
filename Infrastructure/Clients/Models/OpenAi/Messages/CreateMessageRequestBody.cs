using System.Text.Json.Serialization;

namespace Infrastructure.Clients.Models.OpenAi.Messages;

public class CreateMessageRequestBody
{
    [JsonPropertyName("role")] 
    public required string Role { get; set; }

    [JsonPropertyName("content")] 
    public required string Content { get; set; }
}