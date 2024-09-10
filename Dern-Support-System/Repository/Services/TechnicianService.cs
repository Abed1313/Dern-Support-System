﻿using Dern_Support_System.Data;
using Dern_Support_System.Models;
using Dern_Support_System.Models.DTO;
using Dern_Support_System.Repository.interfaces;
using Microsoft.EntityFrameworkCore;

namespace Dern_Support_System.Repository.Services
{
    public class TechnicianService : ITechnician
    {
        private readonly DernSupportDbContext _dbContext;

        public TechnicianService(DernSupportDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Technician>> GetAllTechniciansAsync()
        {
            return await _dbContext.Technicians.ToListAsync();
        }

        public async Task<Technician> GetTechnicianByIdAsync(int technicianId)
        {
            return await _dbContext.Technicians.FindAsync(technicianId);
        }

        public async Task<Technician> AddTechnicianAsync(TechnicianDto technicianDto)
        {
            var technician = new Technician
            {
                Name = technicianDto.Name,
                Specialization = technicianDto.Specialization,
                Availability = technicianDto.Availability,
            };

            _dbContext.Technicians.Add(technician);
            await _dbContext.SaveChangesAsync();
            return technician;
        }

        public async Task<Technician> UpdateTechnicianAsync(TechnicianDto technicianDto, int technicianId)
        {
            var existingTechnician = await _dbContext.Technicians.FindAsync(technicianId);

            if (existingTechnician == null)
            {
                throw new Exception($"Technician with ID {technicianId} not found.");
            }

            if (!string.IsNullOrEmpty(technicianDto.Name)) existingTechnician.Name = technicianDto.Name;
            if (!string.IsNullOrEmpty(technicianDto.Specialization)) existingTechnician.Specialization = technicianDto.Specialization;
            existingTechnician.Availability = technicianDto.Availability;

            await _dbContext.SaveChangesAsync();

            return existingTechnician;
        }

        public async Task DeleteTechnicianAsync(int technicianId)
        {
            var technician = await GetTechnicianByIdAsync(technicianId);
            _dbContext.Technicians.Remove(technician);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Project>> GetProjectsForTechnician(int technicianId)
        {
            var projetcsForTechnician = await _dbContext.TechnicianProjectsDBset
               .Where(ep => ep.TechnicianId == technicianId)
               .Select(ep => ep.Project)
               .ToListAsync();

            return projetcsForTechnician;
        }

        public async Task<TechnicianTask> SubmitARequest(TechnicianTask technicianTask)
        {
            _dbContext.TechnicianTasksDb.Add(technicianTask);
            await _dbContext.SaveChangesAsync();

            return technicianTask;
        }

        public async Task<List<TechnicianTask>> GetAllSubmittedTasks()
        {
            return await _dbContext.TechnicianTasksDb.ToListAsync();
        }

        public async Task<TechnicianTask> UpdateRequestStatus(int taskId, string status)
        {

            var task = await _dbContext.TechnicianTasksDb.FindAsync(taskId);
            if (task == null)
            {
                throw new Exception("Task not found");
            }
            task.Status = status;
            await _dbContext.SaveChangesAsync();

            return task;
        }
    }
}
