namespace Dern_Support_System.Models
{
    public class TechnicianTask
    {
        public int TechnicianTaskId { get; set; }
        public int TechnicianId { get; set; }
        public Technician Technician { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
    }
}
