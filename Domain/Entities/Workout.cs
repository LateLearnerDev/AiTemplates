using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class Workout
{
    [Key] public int Id { get; set; }
    public DateTime Date { get; set; }

    public int UserId { get; set; }
    [ForeignKey(nameof(UserId))] public User User { get; set; } = default!;

    public int? CycleId { get; set; }
    [ForeignKey(nameof(CycleId))] public Cycle? Cycle { get; set; }
}