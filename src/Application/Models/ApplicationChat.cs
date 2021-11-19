namespace Application.Models;

public class ApplicationChat
{
    public int Id { get; set; }

    public bool IsLookingFor(ApplicationApartment apartment)
    {
        return true;
    }
}
