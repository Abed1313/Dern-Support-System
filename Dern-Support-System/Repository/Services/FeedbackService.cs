using Dern_Support_System.Data;
using Dern_Support_System.Models;
using Dern_Support_System.Models.DTO;
using Dern_Support_System.Repository.interfaces;
using Microsoft.EntityFrameworkCore;

namespace Dern_Support_System.Repository.Services
{
    public class FeedbackService : IFeedback
    {
        private readonly DernSupportDbContext _dbContext;

        public FeedbackService(DernSupportDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Feedback>> GetAllFeedbacksAsync()
        {
            return await _dbContext.Feedbacks.ToListAsync();
        }

        public async Task<Feedback> GetFeedbackByIdAsync(int feedbackId)
        {
            return await _dbContext.Feedbacks.FindAsync(feedbackId);
        }

        public async Task<Feedback> AddFeedbackAsync(FeedbackDto feedbackDto)
        {
            var feedback = new Feedback
            {
                CustomerId = feedbackDto.CustomerId,
                SupportRequestId = feedbackDto.SupportRequestId,
                Rating = feedbackDto.Rating,
                Comments = feedbackDto.Comments,
               
            };

            _dbContext.Feedbacks.Add(feedback);
            await _dbContext.SaveChangesAsync();
            return feedback;
        }

        public async Task<Feedback> UpdateFeedbackAsync(FeedbackDto feedbackDto, int feedbackId)
        {
            var existingFeedback = await _dbContext.Feedbacks.FindAsync(feedbackId);

            if (existingFeedback == null)
            {
                throw new KeyNotFoundException($"Feedback with ID {feedbackId} not found.");
            }

            // Update properties
            existingFeedback.CustomerId = feedbackDto.CustomerId;
            existingFeedback.SupportRequestId = feedbackDto.SupportRequestId;
            existingFeedback.Rating = feedbackDto.Rating;
            existingFeedback.Comments = feedbackDto.Comments;

            await _dbContext.SaveChangesAsync();
            return existingFeedback;
        }

        public async Task DeleteFeedbackAsync(int feedbackId)
        {
            var feedback = await GetFeedbackByIdAsync(feedbackId);
            _dbContext.Feedbacks.Remove(feedback);
            await _dbContext.SaveChangesAsync();
        }
    }
}
