using Flatik.Data.Entities;
using Flatik.Monitoring.Models;
using Mapster;

namespace Flatik.Monitoring
{
    public class MapsterConfiguraiton
    {
        public MapsterConfiguraiton()
        {
            //TypeAdapterConfig.GlobalSettings.ForType<Flat, FlatEntity>()
            //    //.Map(dest => dest.Id, src => src.Id)
            //    .Map(dest => dest.SiteName, src => src.Site);
        }
    }
}
