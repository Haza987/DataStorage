using Business.Dtos;
using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Interfaces;

namespace Business.Services;

public class CustomerService(ICustomerRepository customerRepository) : ICustomerService
{
    private readonly ICustomerRepository _customerRepository = customerRepository;

    // Create Customer
    public async Task<bool> CreateCustomerAsync(CustomerDto customer)
    {
        try
        {
            if (await _customerRepository.ExistsAsync(x => x.FirstName == customer.FirstName && x.LastName == customer.LastName))
            {
                Console.WriteLine("Customer name already exists");
                return false;
            }

            var customerEntity = CustomerFactory.CreateEntity(customer);

            var result = await _customerRepository.CreateAsync(customerEntity);
            return result;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to create customer {ex.Message}");
            return false;
        }
    }

    // Read all customers
    public async Task<IEnumerable<Customer>?> GetAllCustomersAsync()
    {
        var customerEntities = await _customerRepository.GetAllAsync();
        var customers = customerEntities?.Select(CustomerFactory.CreateModel);
        return customers;
    }

    // Read one customer
    public async Task<Customer?> GetCustomerByIdAsync(int id)
    {
        var customerEntity = await _customerRepository.GetAsync(x => x.Id == id);

        if (customerEntity == null)
        {
            Console.WriteLine("Customer not found");
            return null;
        }

        var customer = CustomerFactory.CreateModel(customerEntity);
        return customer;
    }

    // Update customer
    public async Task<bool> UpdateCustomerAsync(int id, CustomerUpdateDto updateDto)
    {
        var customerEntity = await _customerRepository.GetAsync(x => x.Id == id);

        if (customerEntity == null)
        {
            Console.WriteLine("Customer not found");
            return false;
        }

        try
        {
            customerEntity = CustomerFactory.Update(customerEntity, updateDto);
            var result = await _customerRepository.UpdateAsync(customerEntity);
            return result;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to update customer {ex.Message}");
            return false;
        }
    }

    // Delete customer
    public async Task<bool> DeleteCustomerAsync(int id)
    {
        var customerEntity = await _customerRepository.GetAsync(x => x.Id == id);

        if (customerEntity == null)
        {
            Console.WriteLine("Customer not found");
            return false;
        }

        try
        {
            var result = await _customerRepository.DeleteAsync(customerEntity);
            return result;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to delete customer {ex.Message}");
            return false;
        }
    }
}
