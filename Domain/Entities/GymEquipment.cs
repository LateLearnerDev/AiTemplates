using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class GymEquipment
{
    [Key] public int Id { get; set; }
    public required string Name { get; set; }

    public int GymId { get; set; }
    [ForeignKey(nameof(GymId))] public Gym Gym { get; set; } = default!;

}