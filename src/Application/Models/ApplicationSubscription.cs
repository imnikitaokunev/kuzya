namespace Application.Models;

public class ApplicationSubscription
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Platform { get; set; }
    public long ChatId { get; set; }
    public bool IsActive { get; set; }
    public double? MinPrice { get; set; }
    public double? MaxPrice { get; set; }
    public int? Rooms { get; set; }
    
    public bool IsAimedAt(ApplicationApartment apartment)
    {
        return (!MinPrice.HasValue || apartment.UsdPrice >= MinPrice.Value) &&
            (!MaxPrice.HasValue || apartment.UsdPrice <= MaxPrice.Value) &&
            (!Rooms.HasValue || apartment.Rooms == Rooms.Value) &&
            apartment.Platform == Platform;
    }
}
