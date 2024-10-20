namespace Domain.Entities;

public class Gym : IEntity
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public ICollection<GymEquipment> GymEquipments { get; set; } = new List<GymEquipment>();
}