using Dern_Support_System.Data;
using Dern_Support_System.Models;
using Dern_Support_System.Models.DTO;
using Dern_Support_System.Repository.interfaces;
using Microsoft.EntityFrameworkCore;

namespace Dern_Support_System.Repository.Services
{
    public class SparePartService : ISparePart
    {
        private readonly DernSupportDbContext _dbContext;

        public SparePartService(DernSupportDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<SparePart>> GetAllSparePartsAsync()
        {
            return await _dbContext.SpareParts.ToListAsync();
        }

        public async Task<SparePart> GetSparePartByIdAsync(int sparePartId)
        {
            return await _dbContext.SpareParts.FindAsync(sparePartId);
        }

        public async Task<SparePart> AddSparePartAsync(SparePartDto sparePartDto)
        {
            var sparePart = new SparePart
            {
                PartName = sparePartDto.PartName,
                StockLevel = sparePartDto.StockLevel,
                ReorderThreshold = sparePartDto.ReorderThreshold,
                PricePerUnit = sparePartDto.PricePerUnit,
            };
            _dbContext.SpareParts.Add(sparePart);
            await _dbContext.SaveChangesAsync();
            return sparePart;
        }

        public async Task<SparePart> UpdateSparePartAsync(SparePartDto sparePartDto, int sparePartId)
        {
            var existingSparePart = await _dbContext.SpareParts.FindAsync(sparePartId);

            if (existingSparePart == null)
            {
                throw new Exception($"SparePart with ID {sparePartId} not found.");
            }

            if (!string.IsNullOrEmpty(sparePartDto.PartName)) existingSparePart.PartName = sparePartDto.PartName;
            existingSparePart.StockLevel = sparePartDto.StockLevel;
            existingSparePart.ReorderThreshold = sparePartDto.ReorderThreshold;
            existingSparePart.PricePerUnit = sparePartDto.PricePerUnit;

            await _dbContext.SaveChangesAsync();

            return existingSparePart;
        }

        public async Task DeleteSparePartAsync(int sparePartId)
        {
            var sparePart = await GetSparePartByIdAsync(sparePartId);
            _dbContext.SpareParts.Remove(sparePart);
            await _dbContext.SaveChangesAsync();
        }
    }
}
