namespace Dern_Support_System.Models
{
    public class Feedback
    {
        public int FeedbackId { get; set; }
        public int CustomerId { get; set; }
        public int SupportRequestId { get; set; }
        public int Rating { get; set; }
        public string Comments { get; set; }

        // Relationships
        public Customer Customer { get; set; }
        public SupportRequest SupportRequest { get; set; }
    }
}
