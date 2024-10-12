using System.ComponentModel.DataAnnotations.Schema;

namespace Lepilina.Models
{
    [Table("Category", Schema = "dbo")]
    public class Category
    {
        public int category_id { get; set; }
        public string name_category { get; set; }
    }
}
