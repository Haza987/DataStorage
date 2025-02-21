using Business.Dtos;
using Business.Interfaces;
using Business.Models;

namespace Presentation_ConsoleApp.Dialogues;

public class EditCustomerDialogue(ICustomerService customerService)
{
    private readonly ICustomerService _customerService = customerService;

    public async Task EditCustomer(Customer customer)
    {
        Console.Clear();
        Console.WriteLine("---------- EDIT CUSTOMER ----------");
        Console.WriteLine($"Current first name: {customer.FirstName}");
        Console.WriteLine("Enter new first name or leave the field blank to keep the current first name: ");
        var firstName = Console.ReadLine();
        if (!string.IsNullOrEmpty(firstName))
        {
            customer.FirstName = firstName;
        }

        Console.Clear();
        Console.WriteLine("---------- EDIT CUSTOMER ----------");
        Console.WriteLine($"Current last name: {customer.LastName}");
        Console.WriteLine("Enter new last name or leave the field blank to keep the current last name: ");
        var lastName = Console.ReadLine();
        if (!string.IsNullOrEmpty(lastName))
        {
            customer.LastName = lastName;
        }

        Console.Clear();
        Console.WriteLine("---------- EDIT CONTACT ----------");
        Console.WriteLine($"Current Email: {customer.Email}");
        Console.WriteLine("Enter new Email address or leave the field blank to keep the current Email address: ");
        var email = Console.ReadLine();
        if (!string.IsNullOrEmpty(email))
        {
            customer.Email = email;
        }

        Console.Clear();
        Console.WriteLine("---------- EDIT CONTACT ----------");
        Console.WriteLine($"Current Address: {customer.Address}");
        Console.WriteLine("Enter new street address or leave the field blank to keep the current street address: ");
        var address = Console.ReadLine();
        if (!string.IsNullOrEmpty(address))
        {
            customer.Address = address;
        }

        Console.Clear();
        Console.WriteLine("---------- EDIT CONTACT ----------");
        Console.WriteLine($"Current Phone number: {customer.PhoneNumber}");
        Console.WriteLine("Enter new phone number or leave the field blank to keep the current phone number: ");
        var phone = Console.ReadLine();
        if (!string.IsNullOrEmpty(phone))
        {
            customer.PhoneNumber = phone;
        }

        var updatedDto = new CustomerUpdateDto
        {
            FirstName = customer.FirstName,
            LastName = customer.LastName,
            Email = customer.Email,
            Address = customer.Address,
            PhoneNumber = customer.PhoneNumber
        };

        await _customerService.UpdateCustomerAsync(customer.Id, updatedDto);

        Console.Clear();
        Console.WriteLine("---------- UPDATED CONTACT ----------");
        Console.WriteLine("Contact updated successfully! Here is the updated contact:");
        Console.WriteLine($"ID: {customer.Id}");
        Console.WriteLine($"Full Name: {customer.FirstName} {customer.LastName}");
        Console.WriteLine($"Email: {customer.Email}");
        Console.WriteLine($"Phone: {customer.PhoneNumber}");
        Console.WriteLine("");
        Console.WriteLine("Press any key to return to the main menu...");
        Console.ReadKey();
    }
}