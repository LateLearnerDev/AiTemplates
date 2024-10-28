namespace Domain.Entities;

public class LoginDetails : Entity
{
    public required string Username { get; set; }
    public required string Password { get; set; }
}