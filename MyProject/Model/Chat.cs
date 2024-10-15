using System.ComponentModel.DataAnnotations;

namespace MyProject.Model
{
    public class Chat
    {
        [Key]
        public int ID { get; set; }  // Primary Key

        public string FromUserId { get; set; }
        public User From {  get; set; }
        public string ToUserId { get; set; }
        public User To { get; set; }
        public string Message { get; set; }
        public DateTime DateTime { get; set; }
    }
}
