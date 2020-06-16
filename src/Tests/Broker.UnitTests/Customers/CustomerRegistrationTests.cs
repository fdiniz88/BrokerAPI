using NSubstitute;
using NUnit.Framework;
using Broker.Domain.Customers;
using Broker.Domain.Customers.Rules;
using Broker.UnitTests.Extensions;

namespace Broker.UnitTests.Customers
{
    [TestFixture]
    public class CustomerRegistrationTests : TestBase
    {
        [Test]
        public void GivenCustomerEmailIsUnique_WhenCustomerIsRegistering_IsSuccessful()
        {
           
            var customerUniquenessChecker = Substitute.For<ICustomerUniquenessChecker>();
            const string email = "testEmail@email.com";
            customerUniquenessChecker.IsUnique(email).Returns(true);

           
            var customer = CustomerService.CreateRegistered(email, "Teste 2", customerUniquenessChecker);

           
            AssertPublishedDomainEvent<CustomerRegisteredEvent>(customer);
        }

        [Test]
        public void GivenCustomerEmailIsNotUnique_WhenCustomerIsRegistering_BreaksCustomerEmailMustBeUniqueRule()
        {
           
            var customerUniquenessChecker = Substitute.For<ICustomerUniquenessChecker>();
            const string email = "testEmail@email.com";
            customerUniquenessChecker.IsUnique(email).Returns(false);
          
            AssertBrokenRule<CustomerEmailMustBeUniqueRule>(() =>
            {               
                CustomerService.CreateRegistered(email, "Teste 3", customerUniquenessChecker);
            });
        }
    }
}