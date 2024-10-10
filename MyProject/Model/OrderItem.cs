using System.ComponentModel.DataAnnotations;

namespace MyProject.Model
{
    public class OrderItem
    {
        [Key]
        public int ID { get; set; }  // Primary Key

        public string ItemName { get; set; }
        public decimal ItemPrice { get; set; }

        public Item Item { get; set; }
    }
}
