using Autofac;
using Broker.Application.Customers.DomainServices;
using Broker.Domain.Customers;
using Broker.Domain.ForeignExchange;
using Broker.Infrastructure.Domain.ForeignExchanges;

namespace Broker.Infrastructure.Domain
{
    public class DomainModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CustomerUniquenessChecker>()
                .As<ICustomerUniquenessChecker>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ForeignExchange>()
                .As<IForeignExchange>()
                .InstancePerLifetimeScope();
        }
    }
}