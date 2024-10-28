namespace Domain.Entities;

public class GymEquipmentExercise : Entity
{
    public int GymEquipmentId { get; set; }
    public GymEquipment GymEquipment { get; set; } = default!;

    public int ExerciseId { get; set; }
    public Exercise Exercise { get; set; } = default!;
}