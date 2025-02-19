using Business.Interfaces;
using Business.Models;

namespace Presentation_ConsoleApp.Dialogues;

public class ViewAllCustomers(ICustomerService customerService)
{
    private readonly ICustomerService _customerService = customerService;

    public async Task GetAllCustomers()
    {
        var customers = await _customerService.GetAllCustomersAsync();
        if (customers != null)
        {
            await ViewCustomers(customers);
        }
        else
        {
            Console.WriteLine("No customers found. Press any key to continue");
            Console.ReadKey();
        }
    }

    public async Task ViewCustomers(IEnumerable<Customer> customers)
    {
        Console.Clear();
        Console.WriteLine("----- VIEW CUSTOMERS -----");
        if (customers.Any())
        {
            foreach (var customer in customers)
            {
                Console.WriteLine($"Customer Id: {customer.Id}");
                Console.WriteLine($"Customer Name: {customer.FirstName} {customer.LastName}");
                Console.WriteLine($"Customer email address: {customer.Email}");
                Console.WriteLine($"Customer street address: {customer.Address}");
                Console.WriteLine($"Customer phone number: {customer.PhoneNumber}");
                Console.WriteLine("-------------------------------");
            }
        }
        else
        {
            Console.WriteLine("No customers found. Press any key to continue");
            Console.ReadKey();
        }
    }
}
