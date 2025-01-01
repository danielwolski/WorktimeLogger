using FunnyWebRazor.Data;
using FunnyWebRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FunnyWebRazor.Pages.Users
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDBContext _context;

        public EditModel(ApplicationDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public User User { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            User = await _context.Users.FindAsync(id);

            if (User == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var userToUpdate = await _context.Users.FindAsync(User.Id);

            if (userToUpdate == null)
            {
                return NotFound();
            }

            // Aktualizacja w³aœciwoœci u¿ytkownika
            userToUpdate.FullName = User.FullName;
            userToUpdate.Email = User.Email;
            userToUpdate.Role = User.Role;

            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
