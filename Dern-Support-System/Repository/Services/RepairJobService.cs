using Dern_Support_System.Data;
using Dern_Support_System.Models;
using Dern_Support_System.Models.DTO;
using Dern_Support_System.Repository.interfaces;
using Microsoft.EntityFrameworkCore;

namespace Dern_Support_System.Repository.Services
{
    public class RepairJobService : IRepairJob
    {
        private readonly DernSupportDbContext _dbContext;

        public RepairJobService(DernSupportDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<RepairJob>> GetAllRepairJobsAsync()
        {
            return await _dbContext.RepairJobs.ToListAsync();
        }

        public async Task<RepairJob> GetRepairJobByIdAsync(int repairJobId)
        {
            return await _dbContext.RepairJobs.FindAsync(repairJobId);
        }

        public async Task<RepairJob> AddRepairJobAsync(RepairJobDto repairJobDto)
        {
            var repairJob = new RepairJob
            {
                SupportRequestId = repairJobDto.SupportRequestId,
                ScheduledDate = repairJobDto.ScheduledDate,
                TechnicianId = repairJobDto.TechnicianId,
                Status = repairJobDto.Status,
            };
            _dbContext.RepairJobs.Add(repairJob);
            await _dbContext.SaveChangesAsync();
            return repairJob;
        }

        public async Task<RepairJob> UpdateRepairJobAsync(RepairJobDto repairJobDto, int repairJobId)
        {
            var existingRepairJob = await _dbContext.RepairJobs.FindAsync(repairJobId);

            if (existingRepairJob == null)
            {
                throw new Exception($"RepairJob with ID {repairJobId} not found.");
            }

            existingRepairJob.ScheduledDate = repairJobDto.ScheduledDate;
            existingRepairJob.TechnicianId = repairJobDto.TechnicianId;
            existingRepairJob.Status = repairJobDto.Status; // Update Status

            // Update CompletionDate and TimeTaken if they are provided
            if (repairJobDto.CompletionDate.HasValue)
            {
                existingRepairJob.CompletionDate = repairJobDto.CompletionDate.Value;
            }

            if (repairJobDto.TimeTaken.HasValue)
            {
                existingRepairJob.TimeTaken = repairJobDto.TimeTaken.Value;
            }

            await _dbContext.SaveChangesAsync();

            return existingRepairJob;
        }


        public async Task DeleteRepairJobAsync(int repairJobId)
        {
            var repairJob = await GetRepairJobByIdAsync(repairJobId);
            _dbContext.RepairJobs.Remove(repairJob);
            await _dbContext.SaveChangesAsync();
        }
    }
}
