namespace Domain.Entities;

public class GymEquipment : IEntity
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public int GymId { get; set; }
    public Gym Gym { get; set; } = default!;
    
    public ICollection<GymEquipmentExercise> GymEquipmentExercises { get; set; } = new List<GymEquipmentExercise>();
    public ICollection<WorkoutExercise> WorkoutExercises { get; set; } = new List<WorkoutExercise>();
}