using Microsoft.AspNetCore.Identity;

namespace Dern_Support_System.Models
{
    public class Customer 
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public string Address { get; set; }
        public string CustomerType { get; set; } // Business or Individual

        // Relationships
        public ICollection<SupportRequest> SupportRequests { get; set; } // One-to-Many
        public ICollection<Feedback> Feedbacks { get; set; } // One-to-Many
    }
}
