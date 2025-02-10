using Business.Interfaces;
using Data.Entities;
using Data.Interfaces;
using System.Linq.Expressions;

namespace Business.Services;

public class CustomerService(ICustomerRepository customerRepository) : ICustomerService
{
    private readonly ICustomerRepository _customerRepository = customerRepository;

    public async Task<bool> CreateCustomerAsync(CustomerEntity customer)
    {
        return await _customerRepository.CreateAsync(customer);
    }

    public async Task<IEnumerable<CustomerEntity>?> GetAllCustomersAsync()
    {
        return await _customerRepository.GetAllAsync();
    }

    public async Task<CustomerEntity?> GetCustomerAsync(Expression<Func<CustomerEntity, bool>> expression)
    {
        return await _customerRepository.GetAsync(expression);
    }

    public async Task<bool> UpdateCustomerAsync(CustomerEntity customer)
    {
        return await _customerRepository.UpdateAsync(customer);
    }

    public async Task<bool> DeleteCustomerAsync(CustomerEntity customer)
    {
        return await _customerRepository.DeleteAsync(customer);
    }

    public async Task<bool> CustomerExistsAsync(Expression<Func<CustomerEntity, bool>> expression)
    {
        return await _customerRepository.ExistsAsync(expression);
    }
}
