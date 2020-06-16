using System.Collections.Generic;
using Broker.Domain.Extensions;

namespace Broker.Domain.Products
{
    public class ProductService : Entity, IAggregateRoot
    {
        public ProductId Id { get; private set; }

        public string Name { get; private set; }

        private List<ProductPrice> _prices;

        private ProductService()
        {

        }
    }
}