using NSubstitute;
using Broker.Domain.Customers;

namespace Broker.UnitTests.Customers
{
    public class CustomerFactory
    {
        public static CustomerService Create()
        {
            var customerUniquenessChecker = Substitute.For<ICustomerUniquenessChecker>();
            var email = "customer@mail.com";
            customerUniquenessChecker.IsUnique(email).Returns(true);

            return CustomerService.CreateRegistered(email, "teste 1", customerUniquenessChecker);
        }
    }
}