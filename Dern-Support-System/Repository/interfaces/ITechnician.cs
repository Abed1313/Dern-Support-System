using Dern_Support_System.Models;
using Dern_Support_System.Models.DTO;

namespace Dern_Support_System.Repository.interfaces
{
    public interface ITechnician
    {
        Task<IEnumerable<Technician>> GetAllTechniciansAsync();
        Task<Technician> GetTechnicianByIdAsync(int technicianId);
        Task<Technician> AddTechnicianAsync(TechnicianDto technicianDto);
        Task<Technician> UpdateTechnicianAsync(TechnicianDto technicianDto, int technicianId);
        Task DeleteTechnicianAsync(int technicianId);

        // New Tasks
        Task<List<TechnicianTask>> GetTasksForTechnician(int technicianId);
        Task<TechnicianTask> SubmitARequest(SubmetAddTask technicianTask);
        Task<List<TechnicianTask>> GetAllSubmittedTasks();
        Task<TechnicianTask> UpdateRequestStatus(int taskId, string status);
    }
}
