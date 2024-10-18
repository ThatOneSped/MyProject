using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace MyProject.Model
{
    public class User : IdentityUser
    {
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Password {  get; set; }
        public string Address { get; set; }
        public List<Chat> SentChats { get; set; }
        public List<Chat> ReceivedChats { get; set; }
    }
}
