namespace Application.Onliner
{
    public class OnlinerResponse
    {
        public IEnumerable<OnlinerDto> Apartments { get; set; }
    }

    public class OnlinerDto
    {
        public long Id { get; set; }
        public string Url { get; set; }
    }
}
