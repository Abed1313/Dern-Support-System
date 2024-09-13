using Dern_Support_System.Models;
using Dern_Support_System.Models.DTO.Response;

namespace Dern_Support_System.Repository.interfaces
{
    public interface ICustomer
    {
        Task<IEnumerable<Customer>> GetAllCustomersAsync();
        Task<Customer> GetCustomerByIdAsync(int customerId);
        Task<Customer> UpdateCustomerAsync(CustomerDto customerDto, int customerId);
        Task DeleteCustomerAsync(int customerId);
    }
}
