using FunnyWebRazor.Data;
using FunnyWebRazor.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FunnyWebRazor.Pages.LogWork
{
    [BindProperties]
    public class CreateModelLogWork : PageModel
    {
        private readonly ApplicationDBContext _db;

        public Worklog Worklog { get; set; }

        public CreateModelLogWork(ApplicationDBContext db)
        {
            _db = db;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
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
