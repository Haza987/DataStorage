using Business.Dtos;
using Business.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Net;

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

        var customerDto = new CustomerDto
        {
            FirstName = customer.FirstName,
            LastName = customer.LastName,
            Email = customer.Email,
            PhoneNumber = customer.PhoneNumber,
            Address = customer.Address
        };

        var result = await _customerService.CreateCustomerAsync(customer);

        try
        {
            if (result)
            {
                Console.WriteLine("Customer added successfully!");
            }
            else
            {
                Console.WriteLine("Failed to add customer.");
            }
        }
        catch (DbUpdateException ex)
        {
            Console.WriteLine("An error occurred while saving the entity changes. See the inner exception for details.");
            Console.WriteLine(ex.InnerException?.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An unexpected error occurred.");
            Console.WriteLine(ex.Message);
        }

        Console.WriteLine("Press any key to return to the main menu.");
        Console.ReadKey();
    }
}
