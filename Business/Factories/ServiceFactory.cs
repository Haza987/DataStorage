using Business.Models;
using Business.Services;
using Data.Entities;

namespace Business.Factories;

public class ServiceFactory
{
    public static Service CreateModel(ServiceEntity serviceEntity) => new()
    {
        ServiceName = serviceEntity.ServiceName,
        HourlyRate = serviceEntity.HourlyRate
    };
}
