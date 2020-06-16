using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Broker.Domain.Products
{
    public interface IProductRepository
    {
        Task<List<ProductService>> GetByIdsAsync(List<ProductId> ids);

        Task<List<ProductService>> GetAllAsync();
    }
}