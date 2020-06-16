using System;
using System.Collections.Generic;
using System.Linq;
using Broker.Domain.Customers.Orders;
using Broker.Domain.Customers.Orders.Events;
using Broker.Domain.Customers.Rules;
using Broker.Domain.ForeignExchange;
using Broker.Domain.Products;
using Broker.Domain.Extensions;

namespace Broker.Domain.Customers
{
    public class CustomerService : Entity, IAggregateRoot
    {
        public CustomerId Id { get; private set; }

        private string _email;

        private string _name;

        private readonly List<OrderService> _orders;   

        private CustomerService()
        {
            this._orders = new List<OrderService>();
        }
         
        private CustomerService(string email, string name)
        {
            this.Id = new CustomerId(Guid.NewGuid());
            _email = email;
            _name = name;       
            _orders = new List<OrderService>();

            this.AddDomainEvent(new CustomerRegisteredEvent(this.Id));
        }

        public static CustomerService CreateRegistered(
            string email, 
            string name,
            ICustomerUniquenessChecker customerUniquenessChecker)
        {
            CheckRule(new CustomerEmailMustBeUniqueRule(customerUniquenessChecker, email));

            return new CustomerService(email, name);
        }

        public OrderId PlaceOrder(
            List<OrderProductData> orderProductsData,
            List<ProductPriceData> allProductPrices,
            string currency, 
            List<ConversionRate> conversionRates)
        {
            CheckRule(new CustomerCannotOrderMoreThan2OrdersOnTheSameDayRule(_orders));
            CheckRule(new OrderMustHaveAtLeastOneProductRule(orderProductsData));

            var order = OrderService.CreateNew(orderProductsData, allProductPrices, currency, conversionRates);

            this._orders.Add(order);

            this.AddDomainEvent(new OrderPlacedEvent(order.Id, this.Id, order.GetValue()));

            return order.Id;
        }

        public void ChangeOrder(
            OrderId orderId, 
            List<ProductPriceData> existingProducts,
            List<OrderProductData> newOrderProductsData,
            List<ConversionRate> conversionRates,
            string currency)
        {
            CheckRule(new OrderMustHaveAtLeastOneProductRule(newOrderProductsData));

            var order = this._orders.Single(x => x.Id == orderId);
            order.Change(existingProducts, newOrderProductsData, conversionRates, currency);

            this.AddDomainEvent(new OrderChangedEvent(orderId));
        }

        public void RemoveOrder(OrderId orderId)
        {
            var order = this._orders.Single(x => x.Id == orderId);
            order.Remove();

            this.AddDomainEvent(new OrderRemovedEvent(orderId));
        }
    }
}