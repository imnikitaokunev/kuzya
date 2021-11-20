namespace Application.Models;

public class ApplicationOnlinerSetup
{
    public long ChatId { get; set; }
    public double? MinPrice { get; set; }
    public double? MaxPrice { get; set; }
    public bool? IsOwner { get; set; }

    public bool IsSatisfy(ApplicationApartment apartment)
    {
        if (apartment == null)
        {
            throw new ArgumentNullException(nameof(apartment));
        }

        if (MinPrice.HasValue && apartment.Amount < MinPrice)
        {
            return false;
        }

        if (MaxPrice.HasValue && apartment.Amount > MaxPrice)
        {
            return false;
        }

        if (IsOwner.HasValue && IsOwner.Value && !apartment.IsOwner)
        {
            return false;
        }

        return true;
    }
}
