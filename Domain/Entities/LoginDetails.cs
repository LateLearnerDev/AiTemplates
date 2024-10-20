namespace Domain.Entities;

public class LoginDetails : IEntity
{
    public int Id { get; set; }
    public required string Username { get; set; }
    public required string Password { get; set; }
}