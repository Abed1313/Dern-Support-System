namespace Dern_Support_System.Models
{
    public class SupportRequest
    {
        public int SupportRequestId { get; set; }
        public int CustomerId { get; set; }
        public string Description { get; set; }
        public string Priority { get; set; }
        public string Status { get; set; }
        public int? QuoteId { get; set; }

        // Relationships
        public Customer Customer { get; set; }
        public Quote Quote { get; set; }
        public ICollection<RepairJob> RepairJobs { get; set; }
        public ICollection<Feedback> Feedback { get; set; }
        public int? KnowledgeBaseId { get; set; }
        public KnowledgeBase KnowledgeBaseArticle { get; set; }
    }
}
