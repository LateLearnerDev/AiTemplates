using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class LoginDetails
{
    [Key] public int Id { get; set; }
    public required string Username { get; set; }
    public required string Password { get; set; }
}