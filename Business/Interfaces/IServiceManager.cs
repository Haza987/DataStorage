using Data.Entities;
using System.Linq.Expressions;

namespace Business.Interfaces
{
    public interface IServiceManager
    {
        Task<bool> CreateServiceAsync(ServiceEntity service);
        Task<bool> DeleteServiceAsync(ServiceEntity service);
        Task<IEnumerable<ServiceEntity>?> GetAllServicesAsync();
        Task<ServiceEntity?> GetServiceAsync(Expression<Func<ServiceEntity, bool>> expression);
        Task<bool> ServiceExistsAsync(Expression<Func<ServiceEntity, bool>> expression);
        Task<bool> UpdateServiceAsync(ServiceEntity service);
    }
}