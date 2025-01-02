using FunnyWebRazor.Data;
using FunnyWebRazor.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FunnyWebRazor.Pages.Users
{
    public class DeleteModel : PageModel
    {
        private readonly UserManager<User> _userManager;

        public DeleteModel(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        [BindProperty]
        public User User { get; set; }

        public async Task<IActionResult> OnGetAsync(string id) 
        {
            User = await _userManager.FindByIdAsync(id);

            if (User == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            var userToDelete = await _userManager.FindByIdAsync(id);

            if (userToDelete == null)
            {
                return NotFound();
            }

            var result = await _userManager.DeleteAsync(userToDelete);

            if (result.Succeeded)
            {
                return RedirectToPage("./Index");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return Page();
        }
    }
}
