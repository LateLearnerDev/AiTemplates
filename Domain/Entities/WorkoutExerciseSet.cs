namespace Domain.Entities;

public class WorkoutExerciseSet 
{
    public int Id { get; set; }
    public int SetNumber { get; set; }
    public int RepCount { get; set; }
    public int Weight { get; set; }

    public int WorkoutExerciseId { get; set; }
    public WorkoutExercise WorkoutExercise { get; set; } = default!;
}