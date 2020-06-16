using System;
using System.Threading.Tasks;

namespace Broker.Domain.Customers.Orders
{
    public interface ICustomerRepository
    {
        Task<CustomerService> GetByIdAsync(CustomerId id);

        Task AddAsync(CustomerService customer);
    }
}