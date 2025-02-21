using Business.Dtos;
using Business.Interfaces;
using Business.Utilities;

namespace Presentation_ConsoleApp.Dialogues;

public class AddProjectDialogue(IProjectService projectService)
{
    private readonly IProjectService _projectService = projectService;

    public async Task AddProject()
    {
        ProjectDto project = new();

        Console.Clear();
        Console.WriteLine("---------- CREATE A NEW PROJECT ----------");

        Console.Write("Enter the name of the project: ");
        project.ProjectName = Console.ReadLine()!;


        Console.Write("Enter the project's start date (DD-MM-YYY): ");
        if (DateParser.TryParseDate(Console.ReadLine()!, out DateTime startDate))
        {
            project.StartDate = startDate;
        }
        else
        {
            Console.WriteLine("Invalid date format. Please enter the date in the format DD-MM-YYYY.");
            Console.ReadKey();
            return;
        }


        Console.Write("Enter the project's end date (DD-MM-YYY): ");
        if (DateParser.TryParseDate(Console.ReadLine()!, out DateTime endDate))
        {
            project.EndDate = endDate;
        }
        else
        {
            Console.WriteLine("Invalid date format. Please enter the date in the format DD-MM-YYYY.");
            Console.ReadKey();
            return;
        }


        Console.Write("Enter the project's status: ");
        project.Status = Console.ReadLine()!;


        Console.Write("Enter the total price of the project: ");
        if (decimal.TryParse(Console.ReadLine(), out decimal totalPrice))
        {
            project.TotalPrice = totalPrice;
        }
        else
        {
            Console.WriteLine("Invalid total price format. Please use numbers with a maximum of 2 decimal places (example 100.00)");
            Console.ReadKey();
            return;
        }


        Console.Write("Enter the customer's ID for the project: ");
        if (int.TryParse(Console.ReadLine(), out int customerId))
        {
            project.CustomerId = customerId;
        }
        else
        {
            Console.WriteLine("Invalid customer ID format. Please refer to all customers view in order to get the Id you require.");
            return;
        }


        Console.Write("Enter the project manager's ID for the project: ");
        if (int.TryParse(Console.ReadLine(), out int projectManagerId))
        {
            project.ProjectManagerId = projectManagerId;
        }
        else
        {
            Console.WriteLine("Invalid project manager ID format. Please refer to all project managers view in order to get the Id you require.");
            return;
        }


        Console.Write("Enter the service's ID for the project: ");
        if (int.TryParse(Console.ReadLine(), out int serviceId))
        {
            project.ServiceId = serviceId;
        }
        else
        {
            Console.WriteLine("Invalid service ID format. Please refer to all services view in order to get the Id you require.");
            return;
        }


        var result = await _projectService.CreateProjectAsync(project);

        if (result)
        {
            Console.WriteLine("Project added successfully!");
        }
        else
        {
            Console.WriteLine("Failed to add project.");
        }

        Console.WriteLine("Press any key to return to the main menu.");
        Console.ReadKey();
    }
}
