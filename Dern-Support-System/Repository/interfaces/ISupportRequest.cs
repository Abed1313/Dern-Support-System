using Dern_Support_System.Models;
using Dern_Support_System.Models.DTO;

namespace Dern_Support_System.Repository.interfaces
{
    public interface ISupportRequest
    {
        Task<IEnumerable<SupportRequest>> GetAllSupportRequestsAsync();
        Task<SupportRequest> GetSupportRequestByIdAsync(int supportRequestId);
        Task<SupportRequest> AddSupportRequestAsync(SupportRequestDto supportRequestDto);
        Task<SupportRequest> UpdateSupportRequestAsync(SupportRequestDto supportRequestDto, int supportRequestId);
        Task DeleteSupportRequestAsync(int supportRequestId);
    }
}
