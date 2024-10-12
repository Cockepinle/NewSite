namespace Lepilina.Models
{
    public class Images
    {
        public int images_id { get; set; }
        public string image_data { get; set; }
        public int? products_id { get; set; }
        public Products Products { get; set; }
    }
}
