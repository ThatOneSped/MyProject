using System.ComponentModel.DataAnnotations;

namespace MyProject.Model
{
    public class Order
    {
        [Key]
        public int ID { get; set; }  // Primary Key

        public string Address { get; set; }
        public decimal TotalPrice { get; set; }

        public User User { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
