namespace Domain.Entities;

public class Test : IEntity
{
    public int Id { get; set; }
    public required string Name { get; set; }
}