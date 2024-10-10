using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class WorkoutExercise
{
    [Key] public int Id { get; set; }
    public string? Notes { get; set; }

    public int WorkoutId { get; set; }
    [ForeignKey(nameof(WorkoutId))] public Workout Workout { get; set; } = default!;

    public int ExerciseId { get; set; }
    [ForeignKey(nameof(ExerciseId))] public Exercise Exercise { get; set; } = default!;
}