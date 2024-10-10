using System.ComponentModel.DataAnnotations;

namespace MyProject.Model
{
    public class Chat
    {
        [Key]
        public int ID { get; set; }  // Primary Key

        public User User { get; set; }
    }
}
