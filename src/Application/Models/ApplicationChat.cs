using Application.Common;

namespace Application.Models;

public class ApplicationChat
{
    public int Id { get; set; }
    public ApplicationOnlinerSetup OnlinerSetup { get; set; }

    public bool IsLookingFor(ApplicationApartment apartment)
    {
        return apartment.Source switch
        {
            Constants.Onliner => OnlinerSetup.IsSatisfy(apartment),
            _ => false,
        };
    }
}
