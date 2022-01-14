namespace Application.Models
{
    public class ApplicationApartment
    {
        public long Id { get; set; }
        public string Platform { get; set; }
        public string Url { get; set; }
        public double Amount { get; set; }
        public string Currency { get; set; }
        public bool IsOwner { get; set; }
    }
}
