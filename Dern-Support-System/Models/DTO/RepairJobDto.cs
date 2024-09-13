namespace Dern_Support_System.Models.DTO
{
    public class RepairJobDto
    {
        public int RepairJobId { get; set; }
        public int SupportRequestId { get; set; } // Nullable if not yet associated
        public DateTime ScheduledDate { get; set; }
        public int TechnicianId { get; set; } // Nullable if not yet assigned
        public string Status { get; set; }
        public DateTime? CompletionDate { get; set; } // Nullable if not completed
        public DateTime? TimeTaken { get; set; } // Change to TimeSpan?
    }

}
