namespace Application.Onliner;

internal class OnlinerPriceDto
{
    public double Amount { get; set; }
    public string Currency { get; set; }
    public OnlinerConvertedDto Converted { get; set; }
}
