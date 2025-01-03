using FunnyWebRazor.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FunnyWebRazor.Pages.Account
{
    public class LogoutModel : PageModel
    {
        private readonly SignInManager<User> _signInManager;

        public LogoutModel(SignInManager<User> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task OnGet()
        {
            Console.WriteLine("Logout initiated");
            await _signInManager.SignOutAsync();
            Response.Redirect("/");
        }
    }
}
