using Microsoft.AspNetCore.Identity;

namespace FunnyWebRazor.Models
{
    public class User : IdentityUser
    {
        public string FullName { get; set; }
    }

}
