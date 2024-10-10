using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Gym
{
    [Key] public int Id { get; set; }
    public required string Name { get; set; }
}