using FunnyWebRazor.Data;
using FunnyWebRazor.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace FunnyWebRazor.Pages.Worklogs
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDBContext _context;

        public IndexModel(ApplicationDBContext context)
        {
            _context = context;
        }

        public List<Worklog> Worklogs { get; set; } = new List<Worklog>();

        public async Task OnGetAsync()
        {
            Worklogs = await _context.Worklogs
                .Include(w => w.User)
                .ToListAsync();
        }
    }
}
