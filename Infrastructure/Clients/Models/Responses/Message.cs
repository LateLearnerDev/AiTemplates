using System.Text.Json.Serialization;
using Application.Messages.Dtos;

namespace Infrastructure.Clients.Models.Responses;

public class Message
{
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("object")]
    public required string Object { get; set; }

    [JsonPropertyName("created_at")]
    public long CreatedAt { get; set; }

    [JsonPropertyName("assistant_id")]
    public string? AssistantId { get; set; }

    [JsonPropertyName("thread_id")]
    public required string ThreadId { get; set; }

    [JsonPropertyName("run_id")]
    public string? RunId { get; set; }

    [JsonPropertyName("role")]
    public required string Role { get; set; }

    [JsonPropertyName("content")]
    public List<MessageContent> Content { get; set; } = [];

    [JsonPropertyName("attachments")]
    public List<object> Attachments { get; set; } = [];

    [JsonPropertyName("metadata")]
    public Dictionary<string, object> Metadata { get; set; } = new();
    
    internal MessageDto ToDto()
    {
        return new MessageDto
        {
            Id = Id,
            ObjectType = Object,
            CreatedAt = DateTimeOffset.FromUnixTimeSeconds(CreatedAt).UtcDateTime,
            AssistantId = AssistantId,
            ThreadId = ThreadId,
            RunId = RunId,
            Role = Role,
            Content = Content.ConvertAll(content => content.ToDto()),
            Attachments = Attachments,
            Metadata = Metadata
        };
    }
}

public class MessageContent
{
    [JsonPropertyName("type")]
    public required string Type { get; set; }

    [JsonPropertyName("text")]
    public required MessageText Text { get; set; }
    
    internal MessageContentDto ToDto()
    {
        return new MessageContentDto
        {
            Type = Type,
            Text = Text.ToDto()
        };
    }
}

public class MessageText
{
    [JsonPropertyName("value")]
    public required string Value { get; set; }

    [JsonPropertyName("annotations")]
    public List<object> Annotations { get; set; } = [];
    
    internal MessageTextDto ToDto()
    {
        return new MessageTextDto
        {
            Value = Value,
            Annotations = Annotations
        };
    }
}