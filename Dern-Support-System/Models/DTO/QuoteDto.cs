namespace Dern_Support_System.Models.DTO
{
    public class QuoteDto
    {
        public int QuoteId { get; set; }
        public int SupportRequestId { get; set; }
        public decimal EstimatedCost { get; set; }
        public decimal FinalCost { get; set; }
    }
}
