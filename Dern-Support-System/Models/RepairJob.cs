namespace Dern_Support_System.Models
{
    public class RepairJob
    {
        public int RepairJobId { get; set; }
        public int SupportRequestId { get; set; }
        public DateTime ScheduledDate { get; set; }
        public int TechnicianId { get; set; }
        public string Status { get; set; }
        public DateTime? CompletionDate { get; set; }
        public DateTime? TimeTaken { get; set; }

        // Relationships
        public SupportRequest SupportRequest { get; set; }
        public Technician Technician { get; set; }
        public ICollection<RepairJobSparePart> RepairJobSpareParts { get; set; }
    }
}
