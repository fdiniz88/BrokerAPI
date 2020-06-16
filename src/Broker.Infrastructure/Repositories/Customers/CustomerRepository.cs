using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Broker.Domain.Customers;
using Broker.Domain.Customers.Orders;
using Broker.Infrastructure.Database;
using Broker.Infrastructure.Extensions;

namespace Broker.Infrastructure.Domain.Customers
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly OrdersContext _context;

        public CustomerRepository(OrdersContext context)
        {
            this._context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task AddAsync(CustomerService customer)
        {
            await this._context.Customers.AddAsync(customer);
        }

        public async Task<CustomerService> GetByIdAsync(CustomerId id)
        {
            return await this._context.Customers
                .IncludePaths(
                    CustomerEntityTypeConfiguration.OrdersList, 
                    CustomerEntityTypeConfiguration.OrderProducts)
                .SingleAsync(x => x.Id == id);
        }
    }
}