using FunnyWebRazor.Data;
using FunnyWebRazor.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace FunnyWebRazor.Pages.LogWork
{
    [Authorize(Roles = "User")]
    public class IndexModelLogWork : PageModel
    {
        private readonly ApplicationDBContext _context;

        public string SortOrder { get; set; }
        public string SearchString { get; set; }

        public IndexModelLogWork(ApplicationDBContext context)
        {
            _context = context;
        }

        public List<Worklog> Worklogs { get; set; } = new List<Worklog>();

        public async Task OnGetAsync(string sortOrder, string searchString)
        {
            SortOrder = sortOrder;
            SearchString = searchString;

            var worklogsQuery = _context.Worklogs.Include(w => w.User).AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                worklogsQuery = worklogsQuery.Where(w => w.User.FullName.Contains(searchString)
                                                       || w.TaskName.Contains(searchString)
                                                       || w.Description.Contains(searchString));
            }

            worklogsQuery = sortOrder switch
            {
                "name_desc" => worklogsQuery.OrderByDescending(w => w.User.FullName),
                "name_asc" => worklogsQuery.OrderBy(w => w.User.FullName),
                "task_desc" => worklogsQuery.OrderByDescending(w => w.TaskName),
                "task_asc" => worklogsQuery.OrderBy(w => w.TaskName),
                "description_desc" => worklogsQuery.OrderByDescending(w => w.Description),
                "description_asc" => worklogsQuery.OrderBy(w => w.Description),
                "start_desc" => worklogsQuery.OrderByDescending(w => w.StartTime),
                "start_asc" => worklogsQuery.OrderBy(w => w.StartTime),
                "end_desc" => worklogsQuery.OrderByDescending(w => w.EndTime),
                "end_asc" => worklogsQuery.OrderBy(w => w.EndTime),
                _ => worklogsQuery.OrderBy(w => w.User.FullName)
            };

            Worklogs = await worklogsQuery.ToListAsync();
        }
    }
}
