using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Broker.Domain.Products;
using Broker.Infrastructure.Database;
using Broker.Infrastructure.Extensions;

namespace Broker.Infrastructure.Domain.Products
{
    public class ProductRepository : IProductRepository
    {
        private readonly OrdersContext _context;
        public ProductRepository(OrdersContext context)
        {
            this._context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<ProductService>> GetByIdsAsync(List<ProductId> ids)
        {
            return await this._context
                .Products
                .IncludePaths("_prices")
                .Where(x => ids.Contains(x.Id)).ToListAsync();
        }

        public async Task<List<ProductService>> GetAllAsync()
        {
            return await this._context
                .Products
                .IncludePaths("_prices")
                .ToListAsync();
        }
    }
}