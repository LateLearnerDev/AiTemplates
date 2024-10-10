using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class Equipment
{
    [Key] public int Id { get; set; }
    public required string Name { get; set; }

    public int GymId { get; set; }
    [ForeignKey(nameof(GymId))] public Gym Gym { get; set; } = default!;

    public int ExerciseId { get; set; }
    [ForeignKey(nameof(ExerciseId))] public Exercise Exercise { get; set; } = default!;
}