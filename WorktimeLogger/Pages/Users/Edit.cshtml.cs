using WorktimeLogger.Data;
using WorktimeLogger.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WorktimeLogger.Pages.Users
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly ApplicationDBContext _db;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public User User { get; set; }
        public string? Password { get; set; }

        public EditModel(ApplicationDBContext db, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _db = db;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            User = await _userManager.FindByIdAsync(id);
            if (User == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(id);
                if (user == null)
                {
                    return NotFound();
                }

                user.FullName = User.FullName;
                user.Email = User.Email;

                if (!string.IsNullOrEmpty(User.UserName) && user.UserName != User.UserName)
                {
                    var existingUser = await _userManager.FindByNameAsync(User.UserName);
                    if (existingUser != null && existingUser.Id != user.Id)
                    {
                        ModelState.AddModelError(string.Empty, "Username is already taken.");
                        return Page();
                    }

                    user.UserName = User.UserName;
                    user.NormalizedUserName = User.UserName.ToUpper();
                }

                if (!string.IsNullOrEmpty(Password))
                {
                    var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                    var passwordChangeResult = await _userManager.ResetPasswordAsync(user, token, Password);

                    if (!passwordChangeResult.Succeeded)
                    {
                        foreach (var error in passwordChangeResult.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                        return Page();
                    }
                }

                var updateResult = await _userManager.UpdateAsync(user);
                if (updateResult.Succeeded)
                {
                    return RedirectToPage("/Users/Index");
                }
                else
                {
                    foreach (var error in updateResult.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    return Page();
                }
            }

            return Page();
        }
    }
}
