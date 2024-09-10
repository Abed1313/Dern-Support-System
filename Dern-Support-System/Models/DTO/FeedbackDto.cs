namespace Dern_Support_System.Models.DTO
{
    public class FeedbackDto
    {
        public int FeedbackId { get; set; }
        public int CustomerId { get; set; }
        public int SupportRequestId { get; set; }
        public int Rating { get; set; } // Assuming a numeric rating system (e.g., 1 to 5)
        public string Comments { get; set; } // Optional comments from the customer

    }
}
