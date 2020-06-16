using FluentValidation;

namespace Broker.Application.Orders.PlaceCustomerOrder
{
    public class PlaceCustomerOrderCommandValidator : AbstractValidator<PlaceCustomerOrderCommand>
    {
        public PlaceCustomerOrderCommandValidator()
        {
            RuleFor(x => x.CustomerId).NotEmpty().WithMessage("CustomerId está vazio");
            RuleFor(x => x.Products).NotEmpty().WithMessage("Products está vazio");
            RuleForEach(x => x.Products).SetValidator(new ProductDtoValidator());

            this.RuleFor(x => x.Currency).Must(x => x == "USD" || x == "EUR")
                .WithMessage("Pelo menos um produto tem moeda inválida");
        }
    }
}