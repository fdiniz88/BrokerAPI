using System.Collections.Generic;
using System.Linq;
using Broker.Domain.Customers.Orders;
using Broker.Domain.Extensions;

namespace Broker.Domain.Customers.Rules
{
    public class CustomerCannotOrderMoreThan2OrdersOnTheSameDayRule : IBusinessRule
    {
        private readonly IList<OrderService> _orders;

        public CustomerCannotOrderMoreThan2OrdersOnTheSameDayRule(IList<OrderService> orders)
        {
            _orders = orders;
        }

        public bool IsBroken()
        {
           return _orders.Count(x => x.IsOrderedToday()) >= 2;
        }

        public string Message => "Você não pode solicitar mais de 2 pedidos no mesmo dia.";
    }
}