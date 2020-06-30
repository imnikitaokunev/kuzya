namespace Flatik.Monitoring.Models
{
    public class SiteModel
    {
        public int Id { get; set; }
        public int Rooms { get; set; }
        public bool IsOwner { get; set; }
        public int UsdPrice { get; set; }
        public int BynPrice { get; set; }
        public string Link { get; set; }
    }
}
