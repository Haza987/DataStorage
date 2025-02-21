using Business.Interfaces;

namespace Presentation_ConsoleApp.Dialogues;

public class FindCustomerEditDialogue(ICustomerService customerService, EditCustomerDialogue editDialogue, DeleteDialogue deleteDialogue)
{
    private readonly ICustomerService _customerService = customerService;
    private readonly EditCustomerDialogue _editDialogue = editDialogue;
    private readonly DeleteDialogue _deleteDialogue = deleteDialogue;

    public async Task FindCustomer(bool isEdit)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("---------- FIND CUSTOMER TO EDIT ----------");

            Console.WriteLine("Enter the customer's ID (Or type M to return to the main menu):");
            var input = Console.ReadLine()!;

            if (input.ToUpper() == "M")
            {
                return;
            }

            if (int.TryParse(input, out var customerId))
            {
                var customer = await _customerService.GetCustomerByIdAsync(customerId);
                if (customer != null)
                {
                    Console.Clear();
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
                            return;

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
}