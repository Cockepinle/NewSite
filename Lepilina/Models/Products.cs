namespace Lepilina.Models
{
    public class Products
    {
        public int products_id { get; set; }
        public string name_products { get; set; }
        public string descriptions { get; set; }
        public decimal price { get; set; }
        public int stocks_quantity { get; set; }

        public int? category_id { get; set; }

        public Category Category { get; set; }
    }
}
