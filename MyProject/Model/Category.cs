using System.ComponentModel.DataAnnotations;

namespace MyProject.Model
{
    public class Category
    {
        [Key]
        public int ID { get; set; }  // Primary Key

        public string? CategoryName { get; set; }

        public ICollection<Item> Items { get; set; }
    }
}
