namespace Application.Threads.Dtos;

public class ThreadDto
{
    public required string Id { get; set; }
    public required string Object { get; set; }
    public long CreatedAt { get; set; }
    public IDictionary<string, object> Metadata { get; set; } = new Dictionary<string, object>();
    public Dictionary<string, object> ToolResources { get; set; } = new();
}