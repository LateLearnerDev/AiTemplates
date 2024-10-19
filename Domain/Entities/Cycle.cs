namespace Domain.Entities;

public class Cycle
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public DateTime? StartDate { get; set; }
    public int LengthInWeeks { get; set; }
    public DateTime? EndDate { get; set; }
    
    public int UserId { get; set; }
    public User User { get; set; } = default!;

    public ICollection<Workout> Workouts { get; set; } = new List<Workout>();
}