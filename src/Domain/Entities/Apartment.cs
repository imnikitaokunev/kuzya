namespace Domain.Entities;

public class Apartment : Entity
{
    public long Id { get; set; }
    public bool IsSent { get; set; }
    public string Platform { get; set; }
    public int Rooms { get; set; }
    public string Link { get; set; }
    public double Price { get; set; }
    public string Currency { get; set; }
    public double UsdPrice { get; set; }
    public bool IsOwner { get; set; }
    public string Address { get; set; }
}
