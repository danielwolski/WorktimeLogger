using Microsoft.AspNetCore.Identity;

namespace WorktimeLogger.Models
{
    public class User : IdentityUser
    {
        public string FullName { get; set; }
    }

}
