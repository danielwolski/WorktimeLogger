using WorktimeLogger.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WorktimeLogger.Pages.AccountDetails
{
    [Authorize(Roles = "User")]
    public class IndexModel : PageModel
    {
        private readonly UserManager<User> _userManager;

        public IndexModel(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public User UserDetails  { get; set; } = new User();

        public async Task OnGetAsync()
        {
             UserDetails = await _userManager.GetUserAsync(User);

            if (UserDetails == null)
            {
                RedirectToPage("/");
            }
        }
    }
}
