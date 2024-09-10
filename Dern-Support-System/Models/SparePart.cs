namespace Dern_Support_System.Models
{
    public class SparePart
    {
        public int SparePartId { get; set; }
        public string PartName { get; set; }
        public int StockLevel { get; set; }
        public int ReorderThreshold { get; set; }
        public decimal PricePerUnit { get; set; }

        // Relationships
        public ICollection<RepairJobSparePart> RepairJobSpareParts { get; set; }
    }
}
