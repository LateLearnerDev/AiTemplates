namespace Domain.Entities;

public class User 
{
    public int Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    
    public int? LoginId { get; set; }
    public LoginDetails? LoginDetails { get; set; }
    
    public ICollection<Workout> Workouts { get; set; } = new List<Workout>();
    public ICollection<Cycle> Cycles { get; set; } = new List<Cycle>();
}