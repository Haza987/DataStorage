using Business.Interfaces;

namespace Presentation_ConsoleApp.Dialogues;

public class ViewProjectByNumberDialogue(IProjectService projectService, ICustomerService customerService, IProjectManagerService projectManagerService, IServiceManager serviceManager)
{
    private readonly IProjectService _projectService = projectService;
    private readonly ICustomerService _customerService = customerService;
    private readonly IProjectManagerService _projectManagerService = projectManagerService;
    private readonly IServiceManager _serviceManager = serviceManager;

    public async Task ViewProjectByNumber()
    {
        Console.Clear();
        Console.WriteLine("----- FIND PROJECT -----");
        Console.WriteLine("Enter the project number (example P-100): ");
        var selectedProject = Console.ReadLine();

        if (!string.IsNullOrEmpty(selectedProject))
        {
            var project = await _projectService.GetProjectByNumberAsync(selectedProject);
            if (project != null)
            {
                var customer = await _customerService.GetCustomerByIdAsync(project.CustomerId);
                var projectManager = await _projectManagerService.GetProjectManagerByIdAsync(project.ProjectManagerId);
                var service = await _serviceManager.GetServiceByIdAsync(project.ServiceId);

                Console.Clear();
                Console.WriteLine("----- PROJECT DETAILS -----");
                Console.WriteLine($"Project Number: {project.ProjectNumber}");
                Console.WriteLine($"Project Name: {project.ProjectName}");
                Console.WriteLine($"Project Start Date: {project.StartDate}");
                Console.WriteLine($"Project End Date: {project.EndDate}");
                Console.WriteLine($"Project Status: {project.Status}");
                Console.WriteLine($"Project Total Price: {project.TotalPrice}");
                Console.WriteLine($"Customer ID: {project.CustomerId}");
                Console.WriteLine($"Customer Name: {customer?.FirstName} {customer?.LastName}");
                Console.WriteLine($"Project Manager ID: {project.ProjectManagerId}");
                Console.WriteLine($"Project Manager Name: {projectManager?.FullName}");
                Console.WriteLine($"Service ID: {project.ServiceId}");
                Console.WriteLine($"Service Name: {service?.ServiceName}");
            }
            else
            {
                Console.WriteLine("Project not found.");
            }
                Console.ReadKey();
        }
        else
        {
            Console.WriteLine("Invalid project number.");
            Console.ReadKey();
        }
    }
}
