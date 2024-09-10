namespace Dern_Support_System.Models
{
    public class Technician
    {
        public int TechnicianId { get; set; }
        public string Name { get; set; }
        public string Specialization { get; set; }
        public string Availability { get; set; }

        // Relationships
        public ICollection<RepairJob> RepairJobs { get; set; } // One-to-Many
        public ICollection<TechnicianProjects> technicianProjects { get; set; }

        public ICollection<TechnicianTask> technicianTasks { get; set; }  // An employee can have many tasks

    }
}
