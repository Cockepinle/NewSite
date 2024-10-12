namespace Lepilina.Models
{
    public class ProductViewModel
    {
        public Products Product { get; set; }
        public List<Images> Images { get; set; } = new List<Images>();
    }
}
