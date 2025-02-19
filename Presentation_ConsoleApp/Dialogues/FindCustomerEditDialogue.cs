using Business.Interfaces;

namespace Presentation_ConsoleApp.Dialogues;

public class FindCustomerEditDialogue
{
    private readonly ICustomerService _customerService;
    private readonly EditCustomerDialogue _editDialogue;
    private readonly DeleteDialogue _deleteDialogue;

    public async Task FindCustomer(bool isEdit)
    {
        Console.Clear();
        Console.WriteLine("---------- FIND CUSTOMER TO EDIT ----------");
        Console.WriteLine("Enter the customer's ID:");
        var input = Console.ReadLine()!;

        if (int.TryParse(input, out var customerId))
        {
            var customer = await _customerService.GetCustomerByIdAsync(customerId);
            if (customer != null)
            {
                Console.WriteLine($"Customer found: {customer.FirstName} {customer.LastName}");
                Console.WriteLine("Is this the customer you are trying to edit? (Y/N)");
                var option = Console.ReadLine()!;

                switch (option.ToUpper())
                {
                    case "Y":
                        if (isEdit)
                        {
                            await _editDialogue.EditCustomer(customer);
                        }
                        else
                        {
                            await _deleteDialogue.DeleteCustomer(customer);
                        }
                        break;

                    case "N":
                        Console.Clear();
                        Console.WriteLine("---------- LOADING ----------");
                        Console.WriteLine("Returning to customer finder...");
                        Console.ReadKey();
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("---------- ERROR ----------");
                        Console.WriteLine("Invalid option. Please try again.");
                        Console.ReadKey();
                        break;
                }
            }
            else
            {
                Console.WriteLine("Customer not found.");
                Console.ReadKey();
            }
        }
        else
        {
            Console.WriteLine("Invalid input.");
            Console.ReadKey();
        }
    }
}