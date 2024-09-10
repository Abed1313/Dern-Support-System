namespace Dern_Support_System.Models
{
    public class Technician
    {
        public int TechnicianId { get; set; }
        public string Name { get; set; }
        public string Specialization { get; set; }
        public string Availability { get; set; }

        // Relationships
        public ICollection<RepairJob> RepairJobs { get; set; }
        public ICollection<TechnicianTask> TechnicianTasks { get; set; }
    }
}
