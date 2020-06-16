using Microsoft.EntityFrameworkCore;
using Broker.Domain.Customers;
using Broker.Domain.Products;


namespace Broker.Infrastructure.Database
{
    public class OrdersContext : DbContext
    {
        public DbSet<CustomerService> Customers { get; set; }
        public DbSet<ProductService> Products { get; set; }    
        public OrdersContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(OrdersContext).Assembly);
        }
    }
}
