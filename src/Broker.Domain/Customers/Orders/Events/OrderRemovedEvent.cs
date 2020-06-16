using Broker.Domain.Extensions;

namespace Broker.Domain.Customers.Orders.Events
{
    public class OrderRemovedEvent : DomainEventBase
    {
        public OrderId OrderId { get; }

        public OrderRemovedEvent(OrderId orderId)
        {
            this.OrderId = orderId;
        }
    }
}