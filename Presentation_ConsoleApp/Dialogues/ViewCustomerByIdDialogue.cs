using Business.Interfaces;

namespace Presentation_ConsoleApp.Dialogues;

public class ViewCustomerByIdDialogue(ICustomerService customerService)
{
    private readonly ICustomerService _customerService = customerService;

    public async Task ViewCustomerById()
    {
        Console.Clear();
        Console.WriteLine("----- FIND CUSTOMER -----");
        Console.WriteLine("Enter the customer ID: ");
        var selectedCustomer = Console.ReadLine();
        if (int.TryParse(selectedCustomer, out var customerId))
        {
            var customer = await _customerService.GetCustomerByIdAsync(customerId);
            if (customer != null)
            {
                Console.Clear();
                Console.WriteLine("----- CUSTOMER DETAILS -----");
                Console.WriteLine($"Customer ID: {customer.Id}");
                Console.WriteLine($"First Name: {customer.FirstName}");
                Console.WriteLine($"Last Name: {customer.LastName}");
                Console.WriteLine($"Email: {customer.Email}");
                Console.WriteLine($"Phone Number: {customer.PhoneNumber}");
                Console.WriteLine($"Address: {customer.Address}");
            }
            else
            {
                Console.WriteLine("Customer not found.");
            }
                Console.ReadKey();
        }
        else
        {
            Console.WriteLine("Invalid customer ID.");
            Console.ReadKey();
        }
    }
}