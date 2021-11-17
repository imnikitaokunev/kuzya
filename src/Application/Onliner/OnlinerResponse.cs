namespace Application.Onliner
{
    public class OnlinerResponse
    {
        public IEnumerable<OnlinerDto> Apartments { get; set; }
        public int Total { get; set; }
    }
}
