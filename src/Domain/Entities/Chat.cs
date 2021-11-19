namespace Domain.Entities;

public class Chat : Entity
{
    public long Id { get; set; }
    public bool IsActive { get; set; }
    public OnlinerSetup OnlinerSetup { get; set; }
}
