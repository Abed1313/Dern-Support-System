using Dern_Support_System.Models;
using Dern_Support_System.Models.DTO;

namespace Dern_Support_System.Repository.interfaces
{
    public interface ISparePart
    {
        Task<IEnumerable<SparePart>> GetAllSparePartsAsync();
        Task<SparePart> GetSparePartByIdAsync(int sparePartId);
        Task<SparePart> AddSparePartAsync(SparePartDto sparePartDto);
        Task<SparePart> UpdateSparePartAsync(SparePartDto sparePartDto, int sparePartId);
        Task DeleteSparePartAsync(int sparePartId);
    }
}
