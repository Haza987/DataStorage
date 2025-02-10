using Data.Entities;
using System.Linq.Expressions;

namespace Business.Interfaces
{
    public interface ICustomerService
    {
        Task<bool> CreateCustomerAsync(CustomerEntity customer);
        Task<IEnumerable<CustomerEntity>?> GetAllCustomersAsync();
        Task<CustomerEntity?> GetCustomerAsync(Expression<Func<CustomerEntity, bool>> expression);
        Task<bool> UpdateCustomerAsync(CustomerEntity customer);
        Task<bool> DeleteCustomerAsync(CustomerEntity customer);
        Task<bool> CustomerExistsAsync(Expression<Func<CustomerEntity, bool>> expression);
    }
}