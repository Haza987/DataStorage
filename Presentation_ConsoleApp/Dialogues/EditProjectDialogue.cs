using Business.Dtos;
using Business.Interfaces;
using Business.Models;

namespace Presentation_ConsoleApp.Dialogues;

public class EditProjectDialogue(IProjectService projectService, ICustomerService customerService, IProjectManagerService projectManagerService, IServiceManager serviceManager)
{
    private readonly IProjectService _projectService = projectService;
    private readonly ICustomerService _customerService = customerService;
    private readonly IProjectManagerService _projectManagerService = projectManagerService;
    private readonly IServiceManager _serviceManager = serviceManager;


    public async Task EditProject(Project project)
    {
        Console.Clear();
        Console.WriteLine("---------- EDIT PROJECT ----------");
        Console.WriteLine($"Current project name: {project.ProjectName}");
        Console.WriteLine("Enter new project name or leave the field blank to keep the current project name: ");
        var projectName = Console.ReadLine();
        if (!string.IsNullOrEmpty(projectName))
        {
            project.ProjectName = projectName;
        }


        Console.Clear();
        Console.WriteLine("---------- EDIT PROJECT ----------");
        Console.WriteLine($"Current project start date: {project.StartDate}");
        Console.WriteLine("Enter new start date (DD-MM-YYYY) or leave the field blank to keep the current start date: ");
        var startDateInput = Console.ReadLine();
        if (!string.IsNullOrEmpty(startDateInput))
        {
            if (DateTime.TryParseExact(startDateInput, "dd-MM-yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime startDate))
            {
                project.StartDate = startDate;
            }
            else
            {
                Console.WriteLine("Invalid date format. Please enter the date in the format DD-MM-YYYY.");
                Console.ReadKey();
                return;
            }
        }
        

        Console.Clear();
        Console.WriteLine("---------- EDIT PROJECT ----------");
        Console.WriteLine($"Current project end date: {project.EndDate}");
        Console.WriteLine("Enter new end date (DD-MM-YYYY) or leave the field blank to keep the current end date: ");
        var endDateInput = Console.ReadLine();
        if (!string.IsNullOrEmpty(endDateInput))
        {
            if (DateTime.TryParseExact(endDateInput, "dd-MM-yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime endDate))
            {
                project.EndDate = endDate;
            }
            else
            {
                Console.WriteLine("Invalid date format. Please enter the date in the format DD-MM-YYYY.");
                Console.ReadKey();
                return;
            }
        }


        Console.Clear();
        Console.WriteLine("---------- EDIT PROJECT ----------");
        Console.WriteLine($"Current status: {project.Status}");
        Console.WriteLine("Enter new status or leave the field blank to keep the current status: ");
        var status = Console.ReadLine();
        if (!string.IsNullOrEmpty(status))
        {
            project.Status = status;
        }


        Console.Clear();
        Console.WriteLine("---------- EDIT PROJECT ----------");
        Console.WriteLine($"Current total price: {project.TotalPrice}");
        Console.WriteLine("Enter new total price or leave the field blank to keep the current total price: ");
        var totalPriceInput = Console.ReadLine();
        if (!string.IsNullOrEmpty(totalPriceInput))
        {
            if (decimal.TryParse(totalPriceInput, out decimal totalPrice))
            {
                project.TotalPrice = totalPrice;
            }
            else
            {
                Console.WriteLine("Invalid total price format. Please use numbers with a maximum of 2 decimal places (example 100.00)");
                Console.ReadKey();
                return;
            }
        }


        Console.Clear();
        Console.WriteLine("---------- EDIT PROJECT ----------");
        Console.WriteLine($"Current customer ID: {project.CustomerId}");
        Console.WriteLine("Enter new customer ID or leave the field blank to keep the current customer ID: ");
        var customerIdInput = Console.ReadLine();
        if (!string.IsNullOrEmpty(customerIdInput))
        {
            if (int.TryParse(customerIdInput, out int customerId))
            {
                project.CustomerId = customerId;
            }
            else
            {
                Console.WriteLine("Invalid customer ID format. Please refer to all customers view in order to get the Id you require.");
                Console.ReadKey();
                return;
            }
        }


        Console.Clear();
        Console.WriteLine("---------- EDIT PROJECT ----------");
        Console.WriteLine($"Current project manager ID: {project.ProjectManagerId}");
        Console.WriteLine("Enter new project manager ID or leave the field blank to keep the current project manager ID: ");
        var projectManagerIdInput = Console.ReadLine();
        if (!string.IsNullOrEmpty(projectManagerIdInput))
        {
            if (int.TryParse(projectManagerIdInput, out int projectManagerId))
            {
                project.ProjectManagerId = projectManagerId;
            }
            else
            {
                Console.WriteLine("Invalid project manager ID format. Please refer to all project managers view in order to get the Id you require.");
                Console.ReadKey();
                return;
            }
        }


        Console.Clear();
        Console.WriteLine("---------- EDIT PROJECT ----------");
        Console.WriteLine($"Current service ID: {project.ServiceId}");
        Console.WriteLine("Enter new service ID or leave the field blank to keep the current service ID: ");
        var serviceIdInput = Console.ReadLine();
        if (!string.IsNullOrEmpty(serviceIdInput))
        {
            if (int.TryParse(serviceIdInput, out int serviceId))
            {
                project.ServiceId = serviceId;
            }
            else
            {
                Console.WriteLine("Invalid service ID format. Please refer to all services view in order to get the Id you require.");
                Console.ReadKey();
                return;
            }
        }


        var updatedDto = new ProjectUpdateDto
        {
            ProjectName = project.ProjectName,
            StartDate = project.StartDate,
            EndDate = project.EndDate,
            Status = project.Status,
            TotalPrice = project.TotalPrice,
            CustomerId = project.CustomerId,
            ProjectManagerId = project.ProjectManagerId,
            ServiceId = project.ServiceId
        };


        await _projectService.UpdateProjectAsync(project.ProjectNumber, updatedDto);

        var customer = await _customerService.GetCustomerByIdAsync(project.CustomerId);
        var projectManager = await _projectManagerService.GetProjectManagerByIdAsync(project.ProjectManagerId);
        var service = await _serviceManager.GetServiceByIdAsync(project.ServiceId);


        Console.Clear();
        Console.WriteLine("---------- UPDATED PROJECT ----------");
        Console.WriteLine("Project updated successfully! Here is the updated project:");
        Console.WriteLine($"Project Number: {project.ProjectNumber}");
        Console.WriteLine($"Project Name: {project.ProjectName}");
        Console.WriteLine($"Start Date: {project.StartDate}");
        Console.WriteLine($"End Date: {project.EndDate}");
        Console.WriteLine($"Status: {project.Status}");
        Console.WriteLine($"Total Price: {project.TotalPrice}");
        Console.WriteLine($"Customer ID: {project.CustomerId}");
        Console.WriteLine($"Customer Name: {customer?.FirstName} {customer?.LastName}");
        Console.WriteLine($"Project Manager ID: {project.ProjectManagerId}");
        Console.WriteLine($"Project Manager Name: {projectManager?.FullName}");
        Console.WriteLine($"Service ID: {project.ServiceId}");
        Console.WriteLine($"Service Name: {service?.ServiceName}");
        Console.WriteLine("");
        Console.WriteLine("Press any key to return to the main menu...");
        Console.ReadKey();
    }
}