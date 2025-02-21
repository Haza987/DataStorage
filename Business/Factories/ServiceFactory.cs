using Business.Models;
using Data.Entities;

namespace Business.Factories;

public class ServiceFactory
{
    public static Service CreateModel(ServiceEntity serviceEntity) => new()
    {
        Id = serviceEntity.Id,
        ServiceName = serviceEntity.ServiceName,
        HourlyRate = serviceEntity.HourlyRate
    };
}