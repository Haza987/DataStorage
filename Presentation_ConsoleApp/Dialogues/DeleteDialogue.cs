using Business.Interfaces;
using Business.Models;

namespace Presentation_ConsoleApp.Dialogues;

public class DeleteDialogue(ICustomerService customerService, IProjectService projectService)
{
    private readonly ICustomerService _customerService = customerService;
    private readonly IProjectService _projectService = projectService;

    public async Task DeleteCustomer(Customer customer)
    {
        Console.Clear();
        Console.WriteLine("---------- DELETE CONTACT ----------");
        Console.WriteLine($"Customer: {customer.FirstName} {customer.LastName}");
        Console.WriteLine("Are you sure you want to delete this contact? (Y/N)");
        var option = Console.ReadLine()!;

        switch (option.ToUpper())
        {
            case "Y":
                Console.Clear();
                Console.WriteLine("-------------------------------");
                Console.WriteLine("Contact deleted successfully. Returning to main menu...");
                await _customerService.DeleteCustomerAsync(customer.Id);
                Console.ReadKey();
                return;

            case "N":
                Console.Clear();
                Console.WriteLine("-------------------------------");
                Console.WriteLine("Contact not deleted. Returning to main menu...");
                Console.ReadKey();
                return;

            default:
                Console.Clear();
                Console.WriteLine("---------- ERROR ----------");
                Console.WriteLine("Invalid choice. Please try again.");
                Console.ReadKey();
                break;
        }
    }

    public async Task DeleteProject(Project project)
    {
        Console.Clear();
        Console.WriteLine("---------- DELETE CONTACT ----------");
        Console.WriteLine($"Customer: {project.ProjectNumber}");
        Console.WriteLine("Are you sure you want to delete this contact? (Y/N)");
        var option = Console.ReadLine()!;

        switch (option.ToUpper())
        {
            case "Y":
                Console.Clear();
                Console.WriteLine("-------------------------------");
                Console.WriteLine("Contact deleted successfully. Returning to main menu...");
                await _projectService.DeleteProjectAsync(project.ProjectNumber);
                Console.ReadKey();
                return;

            case "N":
                Console.Clear();
                Console.WriteLine("-------------------------------");
                Console.WriteLine("Contact not deleted. Returning to main menu...");
                Console.ReadKey();
                return;

            default:
                Console.Clear();
                Console.WriteLine("---------- ERROR ----------");
                Console.WriteLine("Invalid choice. Please try again.");
                Console.ReadKey();
                break;
        }
    }
}
