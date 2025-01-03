using WorktimeLogger.Data;
using WorktimeLogger.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace WorktimeLogger.Pages.LogWork
{
    [Authorize(Roles = "User")]
    public class IndexModelLogWork : PageModel
    {
        private readonly ApplicationDBContext _context;
        private readonly UserManager<User> _userManager;

        public string SortOrder { get; set; }
        public string SearchString { get; set; }

        public IndexModelLogWork(ApplicationDBContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public List<Worklog> Worklogs { get; set; } = new List<Worklog>();

        public async Task OnGetAsync(string sortOrder, string searchString)
        {
            SortOrder = sortOrder;
            SearchString = searchString;

            var user = await _userManager.GetUserAsync(User);

            if (user != null)
            {
                var worklogsQuery = _context.Worklogs
                                            .Include(w => w.User)
                                            .Where(w => w.UserId == user.Id)
                                            .AsQueryable();

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
}
