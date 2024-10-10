using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class Cycle
{
    [Key] public int Id { get; set; }
    public required string Name { get; set; }
    public DateTime? StartDate { get; set; }
    public int LengthInWeeks { get; set; }
    public DateTime? EndDate { get; set; }
    
    public int UserId { get; set; }
    [ForeignKey(nameof(UserId))] public User User { get; set; } = default!;

    public ICollection<Workout> Workouts = new List<Workout>();
}