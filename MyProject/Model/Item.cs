using System.ComponentModel.DataAnnotations;

namespace MyProject.Model
{
    public class Item
    {
        [Key]
        public int ID { get; set; }  // Primary Key

        public string ItemName { get; set; }
        public decimal ItemPrice { get; set; }
        public string? ItemSize { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }

        public Category Category { get; set; }
        public User User { get; set; }
        public string UserId { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
