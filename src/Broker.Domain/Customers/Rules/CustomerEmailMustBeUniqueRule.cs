using Broker.Domain.Extensions;

namespace Broker.Domain.Customers.Rules
{
    public class CustomerEmailMustBeUniqueRule : IBusinessRule
    {
        private readonly ICustomerUniquenessChecker _customerUniquenessChecker;

        private readonly string _email;

        public CustomerEmailMustBeUniqueRule(
            ICustomerUniquenessChecker customerUniquenessChecker, 
            string email)
        {
            _customerUniquenessChecker = customerUniquenessChecker;
            _email = email;
        }

        public bool IsBroken() => !_customerUniquenessChecker.IsUnique(_email);

        public string Message => "O cliente com este email já existe.";
    }
}