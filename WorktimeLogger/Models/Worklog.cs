namespace WorktimeLogger.Models
{
    public class Worklog
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public string TaskName { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }

}
