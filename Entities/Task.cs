using taskTracker.Helpers;

namespace TaskTracker
{
    public class TaskAssignment
    {
        public Byte Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public Status Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}