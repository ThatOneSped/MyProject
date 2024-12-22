using System.ComponentModel.DataAnnotations;

namespace MyProject.Model
{
    public class Payment
    {
        [Key]
        public int ID { get; set; }  // Primary Key

        public string PaymentType { get; set; }

        public int LongNumber { get; set; }

        public DateOnly ExpiryDate { get; set; }

        public string SortCode { get; set; }

        public int CVV { get; set; }

        public required User User { get; set; }

    }
}
