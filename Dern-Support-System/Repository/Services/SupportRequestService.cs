using Dern_Support_System.Data;
using Dern_Support_System.Models;
using Dern_Support_System.Models.DTO;
using Dern_Support_System.Repository.interfaces;
using Microsoft.EntityFrameworkCore;

namespace Dern_Support_System.Repository.Services
{
    public class SupportRequestService : ISupportRequest
    {
        private readonly DernSupportDbContext _dbContext;

        public SupportRequestService(DernSupportDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<SupportRequest>> GetAllSupportRequestsAsync()
        {
            return await _dbContext.SupportRequests.ToListAsync();
        }

        public async Task<SupportRequest> GetSupportRequestByIdAsync(int supportRequestId)
        {
            return await _dbContext.SupportRequests.FindAsync(supportRequestId);
        }

        public async Task<SupportRequest> AddSupportRequestAsync(SupportRequestDto supportRequestDto)
        {
            // Create a new SupportRequest entity using data from the DTO
            var supportRequest = new SupportRequest
            {
                CustomerId = supportRequestDto.CustomerId,
                Description = supportRequestDto.Description,
                Priority = supportRequestDto.Priority,
                Status = supportRequestDto.Status,
                KnowledgeBaseId = supportRequestDto.KnowledgeBaseId, // Nullable field
                QuoteId = supportRequestDto.QuoteId // Nullable field
            };

            // Add the new support request to the repository
            _dbContext.SupportRequests.Add(supportRequest);

            // Save changes to the database
            await _dbContext.SaveChangesAsync();

            return supportRequest;
        }

        public async Task<SupportRequest> UpdateSupportRequestAsync(SupportRequestDto supportRequestDto, int supportRequestId)
        {
            var existingSupportRequest = await _dbContext.SupportRequests.FindAsync(supportRequestId);

            if (existingSupportRequest == null)
            {
                throw new Exception($"SupportRequest with ID {supportRequestId} not found.");
            }

            // Update only the fields that are provided in the DTO
            if (supportRequestDto.KnowledgeBaseId.HasValue)
            {
                existingSupportRequest.KnowledgeBaseId = supportRequestDto.KnowledgeBaseId.Value;
            }

            if (supportRequestDto.QuoteId.HasValue)
            {
                existingSupportRequest.QuoteId = supportRequestDto.QuoteId.Value;
            }

            if (supportRequestDto.CustomerId > 0)
            {
                existingSupportRequest.CustomerId = supportRequestDto.CustomerId;
            }

            if (!string.IsNullOrEmpty(supportRequestDto.Description))
            {
                existingSupportRequest.Description = supportRequestDto.Description;
            }

            if (!string.IsNullOrEmpty(supportRequestDto.Priority))
            {
                existingSupportRequest.Priority = supportRequestDto.Priority;
            }

            if (!string.IsNullOrEmpty(supportRequestDto.Status))
            {
                existingSupportRequest.Status = supportRequestDto.Status;
            }

            // Save changes to the database
            await _dbContext.SaveChangesAsync();

            return existingSupportRequest;
        }

        public async Task DeleteSupportRequestAsync(int supportRequestId)
        {
            var supportRequest = await GetSupportRequestByIdAsync(supportRequestId);
            _dbContext.SupportRequests.Remove(supportRequest);
            await _dbContext.SaveChangesAsync();
        }
    }
}
