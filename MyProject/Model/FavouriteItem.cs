using System.ComponentModel.DataAnnotations;

namespace MyProject.Model
{
    public class FavouriteItem
    {
        [Key]
        public int ID { get; set; }  // Primary Key

        public string ItemName { get; set; }

        public Item Item { get; set; }
        public User User { get; set; }
    }
}
