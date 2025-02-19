using Business.Models;

namespace Business.Interfaces;

public interface IServiceManager
{
    Task<IEnumerable<Service>?> GetAllServicesAsync();
    Task<Service?> GetServiceByIdAsync(int id);
}