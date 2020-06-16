using System.Collections.Generic;
using Broker.Application.Orders;

namespace Broker.API.Orders
{
    public class CustomerOrderRequest
    {
        public List<ProductDto> Products { get; set; }

        public string Currency { get; set; }
    }
}