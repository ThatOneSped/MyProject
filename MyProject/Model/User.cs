using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace MyProject.Model
{
    public class User : IdentityUser
    {
        public required string Name { get; set; }
        public string? Address { get; set; }
        public List<Chat>? SentChats { get; set; }
        public List<Chat>? ReceivedChats { get; set; }
    }
}
