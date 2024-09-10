namespace Dern_Support_System.Models
{
    public class RepairJob
    {
        public int RepairJobId { get; set; }
        public int SupportRequestId { get; set; }
        public DateTime ScheduledDate { get; set; }
        public int TechnicianId { get; set; }
        public string Status { get; set; }
        public DateTime? CompletionDate { get; set; } // Nullable if not yet completed
        public TimeSpan? TimeTaken { get; set; } // Nullable if not yet completed

        // Relationships
        public SupportRequest SupportRequest { get; set; } // Many-to-One
        public Technician Technician { get; set; } // Many-to-One

        // Many-to-Many relationship with SparePart
        public ICollection<RepairJobSparePart> RepairJobSpareParts { get; set; }
    }
}
