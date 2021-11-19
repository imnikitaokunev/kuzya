namespace Domain.Entities;

public class OnlinerSetup : Entity
{
    public long ChatId { get; set; }
    public double MinPrice { get; set; }
    public double MaxPrice { get; set; }
}
