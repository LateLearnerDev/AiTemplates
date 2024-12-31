namespace Application.OpenAi.Messages.Dtos;

public class MessageDto
{
    public required string Id { get; set; }

    public required string ObjectType { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? AssistantId { get; set; }

    public required string ThreadId { get; set; }

    public string? RunId { get; set; }

    public required string Role { get; set; }

    public List<MessageContentDto> Content { get; set; } = new();

    public List<object> Attachments { get; set; } = new();

    public Dictionary<string, object> Metadata { get; set; } = new();
}

public class MessageContentDto
{
    public required string Type { get; set; }

    public required MessageTextDto Text { get; set; }
}

public class MessageTextDto
{
    public required string Value { get; set; }

    public List<object> Annotations { get; set; } = new();
}