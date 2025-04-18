namespace Domain.Entities;

public class Exercise : Entity
{
    public required string Name { get; set; }
    public string? Description { get; set; }
    
    public ICollection<GymEquipmentExercise> GymEquipmentExercises { get; set; } = new List<GymEquipmentExercise>();
    public ICollection<WorkoutExercise> WorkoutExercises { get; set; } = new List<WorkoutExercise>();
}