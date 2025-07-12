namespace Persistence.Models
{
    public class Theme
    {
        public int ID { get; set; }
        public string Title { get; set; }

        public ICollection<Marker> Markers { get; set; } = new List<Marker>();
    }
}
