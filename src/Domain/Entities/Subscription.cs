namespace Domain.Entities;

public class Subscription : Entity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Platform { get; set; }
    public long ChatId { get; set; }
    public bool IsActive { get; set; }
    public double? MinPrice { get; set; }
    public double? MaxPrice { get; set; } 
    public int? Rooms { get; set; }
}
