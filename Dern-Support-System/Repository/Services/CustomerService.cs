using Dern_Support_System.Data;
using Dern_Support_System.Models;
using Dern_Support_System.Models.DTO.Response;
using Dern_Support_System.Repository.interfaces;
using Microsoft.EntityFrameworkCore;

namespace Dern_Support_System.Repository.Services
{
    public class CustomerService : ICustomer
    {
        private readonly DernSupportDbContext _customerRepository;

        public CustomerService(DernSupportDbContext customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            var customer =await _customerRepository.Customers.ToListAsync();
            return customer;
        }

        public async Task<Customer> GetCustomerByIdAsync(int customerId)
        {
            var customer = await _customerRepository.Customers.FindAsync(customerId);
            return customer;
        }

       

        public async Task<Customer> UpdateCustomerAsync(CustomerDto customerDto, int customerId)
        {
            var existingCustomer = await _customerRepository.Customers.FindAsync(customerId);

            if (existingCustomer == null)
            {
                // Handle case where customer is not found, e.g., throw exception or return null
                throw new Exception($"Customer with ID {customerId} not found.");
            }

            // Update only non-null or non-empty fields
            if (!string.IsNullOrEmpty(customerDto.Name))
            {
                existingCustomer.Name = customerDto.Name;
            }

            if (!string.IsNullOrEmpty(customerDto.Email))
            {
                existingCustomer.Email = customerDto.Email;
            }

            if (!string.IsNullOrEmpty(customerDto.Address))
            {
                existingCustomer.Address = customerDto.Address;
            }

            if (!string.IsNullOrEmpty(customerDto.PhoneNumber))
            {
                existingCustomer.PhoneNumber = customerDto.PhoneNumber;
            }
                existingCustomer.CustomerType = customerDto.CustomerType;
            

            // Save changes to the database
            await _customerRepository.SaveChangesAsync();

            return existingCustomer;
        }


        public async Task DeleteCustomerAsync(int customerId)
        {
            var customer = await GetCustomerByIdAsync(customerId);
            _customerRepository.Customers.Remove(customer);
            await _customerRepository.SaveChangesAsync();
        }
    }

}
