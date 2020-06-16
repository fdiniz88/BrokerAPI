using System;
using Broker.Domain.Extensions;

namespace Broker.Domain.Products
{
    public class ProductId : TypedIdValueBase
    {
        public ProductId(Guid value) : base(value)
        {
        }
    }
}