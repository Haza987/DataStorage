using Business.Dtos;
using Business.Models;

namespace Business.Interfaces
{
    public interface ICustomerService
    {
        Task<bool> CreateCustomerAsync(CustomerDto customer);
        Task<IEnumerable<Customer>?> GetAllCustomersAsync();
        Task<Customer?> GetCustomerByIdAsync(int id);
        Task<bool> UpdateCustomerAsync(int id, CustomerUpdateDto updateDto);
        Task<bool> DeleteCustomerAsync(int id);
    }
}