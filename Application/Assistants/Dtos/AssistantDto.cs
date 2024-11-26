namespace Application.Assistants.Dtos;

public class AssistantDto
{
    public required string Id { get; set; }
    public string ObjectType { get; set; }
    public long CreatedAt { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public required string Model { get; set; }
    public string? Instructions { get; set; }
    public IEnumerable<Tool> Tools { get; set; } = [];
    public Dictionary<string, string>? Metadata { get; set; }
    public double TopP { get; set; }
    public double Temperature { get; set; }
    public required string ResponseFormat { get; set; }
}

public class Tool
{
    public required string Type { get; set; }
}