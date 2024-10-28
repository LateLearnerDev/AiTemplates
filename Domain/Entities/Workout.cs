namespace Domain.Entities;

public class Workout : Entity
{
    public DateTime Date { get; set; }

    public int UserId { get; set; }
    public User User { get; set; } = default!;

    public int? CycleId { get; set; }
    public Cycle? Cycle { get; set; }
    public ICollection<WorkoutExercise> WorkoutExercises { get; set; } = new List<WorkoutExercise>();
}