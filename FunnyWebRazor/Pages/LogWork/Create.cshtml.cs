using FunnyWebRazor.Data;
using FunnyWebRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;

namespace FunnyWebRazor.Pages.LogWork
{
    [BindProperties]
    public class CreateModelLogWork : PageModel
    {
        private readonly ApplicationDBContext _db;
        private readonly UserManager<User> _userManager;

        public Worklog Worklog { get; set; }

        public CreateModelLogWork(ApplicationDBContext db, UserManager<User> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            ModelState.Remove("Worklog.UserId");
            ModelState.Remove("Worklog.User");

            var user = _userManager.GetUserAsync(User).Result;
            if (user != null)
            {
                Worklog.UserId = user.Id;
                Worklog.User = user;
            } else
            {
                ModelState.AddModelError("Worklog.User", "User is required.");
                ModelState.AddModelError("Worklog.UserId", "UserId is required.");
            }

            if (ModelState.IsValid)
            {
                _db.Worklogs.Add(Worklog);
                _db.SaveChanges();
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}
