using Newtonsoft.Json;
using Broker.Application.Configuration.DomainEvents;
using Broker.Domain.Customers;

namespace Broker.Application.Customers.IntegrationHandlers
{
    public class CustomerRegisteredNotification : DomainNotificationBase<CustomerRegisteredEvent>
    {
        public CustomerId CustomerId { get; }

        public CustomerRegisteredNotification(CustomerRegisteredEvent domainEvent) : base(domainEvent)
        {
            this.CustomerId = domainEvent.CustomerId;
        }

        [JsonConstructor]
        public CustomerRegisteredNotification(CustomerId customerId) : base(null)
        {
            this.CustomerId = customerId;
        }
    }
}