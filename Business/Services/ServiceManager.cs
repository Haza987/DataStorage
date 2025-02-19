using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Entities;
using Data.Interfaces;
using Data.Repositories;
using System.Linq.Expressions;

namespace Business.Services;

public class ServiceManager(IServiceRepository serviceRepository) : IServiceManager
{
    private readonly IServiceRepository _serviceRepository = serviceRepository;

    public async Task<IEnumerable<Service>?> GetAllServicesAsync()
    {
        var serviceEntities = await _serviceRepository.GetAllAsync();
        var services = serviceEntities?.Select(ServiceFactory.CreateModel);
        return services;
    }

    public async Task<Service?> GetServiceByIdAsync(int id)
    {
        var serviceEntity = await _serviceRepository.GetAsync(x => x.Id == id);

        if (serviceEntity == null)
        {
            Console.WriteLine("Service not found");
            return null;
        }

        var service = ServiceFactory.CreateModel(serviceEntity);
        return service;
    }
}
