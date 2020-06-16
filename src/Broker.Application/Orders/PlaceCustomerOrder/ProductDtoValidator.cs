using FluentValidation;

namespace Broker.Application.Orders.PlaceCustomerOrder
{
    public class ProductDtoValidator : AbstractValidator<ProductDto>
    {
        public ProductDtoValidator()
        {
            this.RuleFor(x => x.Quantity).GreaterThan(0)
                .WithMessage("Pelo menos um produto tem quantidade inválida");
        }
    }
}