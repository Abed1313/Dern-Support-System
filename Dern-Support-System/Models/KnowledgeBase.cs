﻿namespace Dern_Support_System.Models
{
    public class KnowledgeBase
    {
        public int KnowledgeBaseId { get; set; }
        public string Title { get; set; }
        public string ProblemDescription { get; set; }
        public string SolutionSteps { get; set; }
        public string HardwareOrSoftware { get; set; } // Hardware or Software issue

        public ICollection<SupportRequest> SupportRequests { get; set; } // One-to-Many

    }
}
