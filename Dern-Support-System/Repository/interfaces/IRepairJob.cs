using Dern_Support_System.Models;
using Dern_Support_System.Models.DTO;

namespace Dern_Support_System.Repository.interfaces
{
    public interface IRepairJob
    {
        Task<IEnumerable<RepairJob>> GetAllRepairJobsAsync();
        Task<RepairJob> GetRepairJobByIdAsync(int repairJobId);
        Task<RepairJob> AddRepairJobAsync(RepairJobDto repairJobDto);
        Task<RepairJob> UpdateRepairJobAsync(RepairJobDto repairJobDto, int repairJobId);
        Task DeleteRepairJobAsync(int repairJobId);
    }
}
