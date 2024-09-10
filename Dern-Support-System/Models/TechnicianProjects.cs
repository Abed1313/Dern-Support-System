namespace Dern_Support_System.Models
{
    public class TechnicianProjects
    {
        public int TechnicianId { get; set; }
        public Technician Technician { get; set; }


        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
