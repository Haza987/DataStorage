using Business.Interfaces;
using Data.Entities;
using Data.Interfaces;
using System.Linq.Expressions;

namespace Business.Services;

public class ServiceManager(IServiceRepository serviceRepository) : IServiceManager
{
    private readonly IServiceRepository _serviceRepository = serviceRepository;

    public async Task<bool> CreateServiceAsync(ServiceEntity service)
    {
        return await _serviceRepository.CreateAsync(service);
    }

    public async Task<IEnumerable<ServiceEntity>?> GetAllServicesAsync()
    {
        return await _serviceRepository.GetAllAsync();
    }

    public async Task<ServiceEntity?> GetServiceAsync(Expression<Func<ServiceEntity, bool>> expression)
    {
        return await _serviceRepository.GetAsync(expression);
    }

    public async Task<bool> UpdateServiceAsync(ServiceEntity service)
    {
        return await _serviceRepository.UpdateAsync(service);
    }

    public async Task<bool> DeleteServiceAsync(ServiceEntity service)
    {
        return await _serviceRepository.DeleteAsync(service);
    }

    public async Task<bool> ServiceExistsAsync(Expression<Func<ServiceEntity, bool>> expression)
    {
        return await _serviceRepository.ExistsAsync(expression);
    }
}
