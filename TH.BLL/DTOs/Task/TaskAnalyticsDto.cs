namespace TH.BLL.DTOs.Task
{
    public class TaskAnalyticsDto
    {
        public int TotalTasks { get; set; }

        public int CompletedTasks { get; set; }

        public int PendingTasks { get; set; }

        public int OverdueTasks { get; set; }

        public double CompletionRate { get; set; }
    }
}