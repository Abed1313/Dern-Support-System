namespace Dern_Support_System.Models
{
    public class RepairJobSparePart
    {
        public int RepairJobId { get; set; }
        public RepairJob RepairJob { get; set; }

        public int SparePartId { get; set; }
        public SparePart SparePart { get; set; }

        public int Quantity { get; set; } // Quantity of the spare part used
    }
}
