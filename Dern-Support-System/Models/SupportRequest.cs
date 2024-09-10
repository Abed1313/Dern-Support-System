namespace Dern_Support_System.Models
{
    public class SupportRequest
    {
        public int SupportRequestId { get; set; }
        public int CustomerId { get; set; }
        public string Description { get; set; }
        public string Priority { get; set; }
        public string Status { get; set; }
        public int? QuoteId { get; set; } // Nullable if no quote yet

        // Relationships
        public Customer Customer { get; set; } // Many-to-One
        public Quote Quote { get; set; } // One-to-One
        public ICollection<RepairJob> RepairJobs { get; set; } // One-to-Many
        public ICollection<Feedback> Feedback { get; set; } // One-to-Many
        public int? KnowledgeBaseId { get; set; } // Nullable if no article referenced
        public KnowledgeBase KnowledgeBaseArticle { get; set; } // Many-to-One
    }
    }
