using Data.Contexts;
using Data.Entities;
using Data.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace Data.Repositories;

//GitHub Copilot suggested the (context, cache) parameters in the constructor in order to use the BaseRepository class.
public class CustomerRepository(DataContext context, IMemoryCache cache) : BaseRepository<CustomerEntity>(context, cache), ICustomerRepository
{
}
