using Application.Models;

namespace Application.Common.Interfaces;

public interface IChatNotifier
{
    Task NotifyAsync(IEnumerable<ApplicationApartment> apartments);
}
