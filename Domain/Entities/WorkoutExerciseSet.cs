using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class WorkoutExerciseSet
{
    [Key] public int Id { get; set; }
    public int SetNumber { get; set; }
    public int RepCount { get; set; }
    public int Weight { get; set; }

    public int WorkoutExerciseId { get; set; }

    [ForeignKey(nameof(WorkoutExerciseId))]
    public WorkoutExercise WorkoutExercise { get; set; } = default!;
}