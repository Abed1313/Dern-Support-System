namespace Dern_Support_System.Models.DTO
{
    public class SupportRequestDto
    {
        public int SupportRequestId { get; set; }
        public int? KnowledgeBaseId { get; set; }
        public int? QuoteId { get; set; }
        public int CustomerId { get; set; } // ID of the customer submitting the support request
        public string Description { get; set; } // Detailed description of the support issue
        public string Priority { get; set; } // Priority of the request, e.g., Low, Medium, High
        public string Status { get; set; } // Current status of the request, e.g., Pending, InProgress, Completed

    }
}
