namespace Domain.Entities;

public class WorkoutExercise : IEntity
{
    public int Id { get; set; }
    public string? Notes { get; set; }

    public int WorkoutId { get; set; }
    public Workout Workout { get; set; } = default!;

    public int ExerciseId { get; set; }
    public Exercise Exercise { get; set; } = default!;
    
    public int? GymEquipmentId { get; set; }
    public GymEquipment? GymEquipment { get; set; }
    
    public ICollection<WorkoutExerciseSet> WorkoutExerciseSets { get; set; } = new List<WorkoutExerciseSet>();
}