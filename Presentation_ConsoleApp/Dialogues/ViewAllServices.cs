using Business.Interfaces;
using Business.Models;

namespace Presentation_ConsoleApp.Dialogues;

public class ViewAllServices(IServiceManager serviceManager)
{
    private readonly IServiceManager _serviceManager = serviceManager;

    public async Task GetAllServices()
    {
        var services = await _serviceManager.GetAllServicesAsync();
        if (services != null)
        {
            await ViewServices(services);
        }
        else
        {
            Console.WriteLine("No services found. Press any key to continue");
            Console.ReadKey();
        }
    }

    public async Task ViewServices(IEnumerable<Service> services)
    {
        Console.Clear();
        Console.WriteLine("----- VIEW SERVICES -----");
        Console.WriteLine("-------------------------------");
        if (services.Any())
        {
            foreach (var service in services)
            {
                Console.WriteLine($"Service name: {service.ServiceName}");
                Console.WriteLine($"Service hourly rate: {service.HourlyRate}");
                Console.WriteLine("-------------------------------");
            }
        }
        else
        {
            Console.WriteLine("No services found. Press any key to continue");
            Console.ReadKey();
        }
    }
}
