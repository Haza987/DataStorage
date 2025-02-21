using Business.Dtos;
using Business.Interfaces;

namespace Presentation_ConsoleApp.Dialogues;

public class AddCustomerDialogue(ICustomerService customerService)
{
    private readonly ICustomerService _customerService = customerService;

    public async Task AddCustomer()
    {
        CustomerDto customer = new();

        Console.Clear();
        Console.WriteLine("---------- CREATE A NEW CONTACT ----------");

        Console.Write("Enter your first name: ");
        customer.FirstName = Console.ReadLine()!;

        Console.Write("Enter your last name: ");
        customer.LastName = Console.ReadLine()!;

        Console.Write("Enter your email address: ");
        customer.Email = Console.ReadLine()!;

        Console.Write("Enter your phone number: ");
        customer.PhoneNumber = Console.ReadLine()!;

        Console.Write("Enter your street address: ");
        customer.Address = Console.ReadLine()!;

        var result = await _customerService.CreateCustomerAsync(customer);

        if (result)
        {
            Console.WriteLine("Customer added successfully!");
        }
        else
        {
            Console.WriteLine("Failed to add customer.");
        }

        Console.WriteLine("Press any key to return to the main menu.");
        Console.ReadKey();
    }
}