using Dern_Support_System.Models;
using Dern_Support_System.Models.DTO;

namespace Dern_Support_System.Repository.interfaces
{
    public interface IFeedback
    {
        Task<IEnumerable<Feedback>> GetAllFeedbacksAsync();
        Task<Feedback> GetFeedbackByIdAsync(int feedbackId);
        Task<Feedback> AddFeedbackAsync(FeedbackDto feedbackDto);
        Task<Feedback> UpdateFeedbackAsync(FeedbackDto feedbackDto, int feedbackId);
        Task DeleteFeedbackAsync(int feedbackId);
    }
}
