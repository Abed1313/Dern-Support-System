namespace Dern_Support_System.Models
{
    public class Quote
    {
        public int QuoteId { get; set; }
        public int SupportRequestId { get; set; }
        public decimal EstimatedCost { get; set; }
        public decimal FinalCost { get; set; }

        // Relationships
        public SupportRequest SupportRequest { get; set; }
    }
}
