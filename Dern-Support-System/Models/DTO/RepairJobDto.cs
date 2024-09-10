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
        public TimeSpan? TimeTaken { get; set; } // Nullable if not completed
        public List<int> SparePartIds { get; set; } // List of spare part IDs associated with the job

    }
}
