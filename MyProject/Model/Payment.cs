using System.ComponentModel.DataAnnotations;

namespace MyProject.Model
{
    public class Payment
    {
        [Key]
        public int ID { get; set; }  // Primary Key

        public string PaymentType { get; set; }

        public User User { get; set; }
    }
}
