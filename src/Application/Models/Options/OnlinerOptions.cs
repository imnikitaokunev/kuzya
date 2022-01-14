namespace Application.Models.Options
{
    public record OnlinerOptions
    {
        public const string Onliner = "Onliner";

        public string BaseUrl { get; set; }
    }
}
