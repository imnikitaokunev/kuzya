namespace Application.Onliner;

internal class OnlinerApartmentDto
{
    public long Id { get; set; }
    public OnlinerPriceDto Price { get; set; }
    public string RentType { get; set; }
    public OnlinerLocation Location { get; set; }
    public OnlinerContactDto Contact { get; set; }
    public string Url { get; set; }
}
