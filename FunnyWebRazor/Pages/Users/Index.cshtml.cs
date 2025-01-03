using FunnyWebRazor.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace FunnyWebRazor.Pages.Users
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly UserManager<User> _userManager;

        public IndexModel(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public List<User> Users { get; set; } = new List<User>();

        public async Task OnGetAsync()
        {
            Users = await _userManager.Users.ToListAsync();
        }
    }
}
