namespace Application.Onliner;

internal class OnlinerResponse
{
    public IEnumerable<OnlinerApartmentDto> Apartments { get; set; }
    public int Total { get; set; }
}
