using Business.Interfaces;
using Business.Models;
using Business.Services;

namespace Presentation_ConsoleApp.Dialogues;

public class ViewAllProjects(IProjectService projectService, ICustomerService customerService, IProjectManagerService projectManagerService, IServiceManager serviceManager)
{
    private readonly IProjectService _projectService = projectService;
    private readonly ICustomerService _customerService = customerService;
    private readonly IProjectManagerService _projectManagerService = projectManagerService;
    private readonly IServiceManager _serviceManager = serviceManager;

    public async Task GetAllProjects()
    {
        var projects = await _projectService.GetAllProjectsAsync();
        if (projects != null)
        {
            await ViewProjects(projects);
        }
        else
        {
            Console.WriteLine("No projects found. Press any key to continue");
            Console.ReadKey();
        }

    }

    public async Task ViewProjects(IEnumerable<Project> projects)
    {
        Console.Clear();
        Console.WriteLine("----- VIEW PROJECTS -----");
        Console.WriteLine("-------------------------------");
        if (projects.Any())
        {
            foreach (var project in projects)
            {

                var customer = await _customerService.GetCustomerByIdAsync(project.CustomerId);
                var projectManager = await _projectManagerService.GetProjectManagerByIdAsync(project.ProjectManagerId);
                var service = await _serviceManager.GetServiceByIdAsync(project.ServiceId);


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
                Console.WriteLine("-------------------------------");
            }
            Console.ReadKey();
        }
        else
        {
            Console.WriteLine("No projects found. Press any key to continue");
            Console.ReadKey();
        }
    }
}
