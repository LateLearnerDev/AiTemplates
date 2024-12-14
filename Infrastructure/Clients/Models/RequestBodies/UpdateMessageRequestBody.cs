using System.Text.Json.Serialization;

namespace Infrastructure.Clients.Models.RequestBodies;

public class UpdateMessageRequestBody
{
    [JsonPropertyName("metadata")]
    public required Dictionary<string, object> MetaData;
}