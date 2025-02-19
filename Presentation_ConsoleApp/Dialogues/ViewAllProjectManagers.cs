using Business.Interfaces;
using Business.Models;

namespace Presentation_ConsoleApp.Dialogues;

public class ViewAllProjectManagers(IProjectManagerService projectManagerService)
{
    private readonly IProjectManagerService _projectManagerService = projectManagerService;

    public async Task GetAllProjectManagers()
    {
        var projectManagers = await _projectManagerService.GetAllProjectManagersAsync();
        if (projectManagers != null)
        {
            await ViewProjectManagers(projectManagers);
        }
        else
        {
            Console.WriteLine("No project managers found. Press any key to continue");
            Console.ReadKey();
        }
    }

    public async Task ViewProjectManagers(IEnumerable<ProjectManager> projectManagers)
    {
        Console.Clear();
        Console.WriteLine("----- VIEW PROJECT MANAGERS -----");
        Console.WriteLine("-------------------------------");
        if (projectManagers.Any())
        {
            foreach (var projectManager in projectManagers)
            {
                Console.WriteLine($"Project Manager Name: {projectManager.FullName}");
                Console.WriteLine($"Project Manager Email: {projectManager.Email}");
                Console.WriteLine($"Project Manager Phone Number: {projectManager.PhoneNumber}");
                Console.WriteLine("-------------------------------");
            }
        }
        else
        {
            Console.WriteLine("No project managers found. Press any key to continue");
            Console.ReadKey();
        }
    }
}
