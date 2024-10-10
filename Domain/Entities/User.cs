using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class User
{
    [Key] public int Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastNameName { get; set; }
    
    public int? LoginId { get; set; }
    [ForeignKey(nameof(LoginId))] public LoginDetails? LoginDetails { get; set; }
    
    public ICollection<Workout> Workouts { get; set; } = new List<Workout>();
}