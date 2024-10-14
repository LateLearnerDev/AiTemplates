using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class GymEquipmentExercise
{
    [Key] public int Id { get; set; }
    
    public int GymEquipmentId { get; set; }
    [ForeignKey(nameof(GymEquipmentId))] public GymEquipment GymEquipment { get; set; } = default!;

    public int ExerciseId { get; set; }
    [ForeignKey(nameof(ExerciseId))] public Exercise Exercise { get; set; } = default!;
}