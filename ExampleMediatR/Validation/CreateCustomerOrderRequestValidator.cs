using ExampleMediatR.Requests;

using FluentValidation;

namespace ExampleMediatR.Validation
{
    public class CreateCustomerOrderRequestValidator : AbstractValidator<CreateCustomerOrderRequest>
    {
        public CreateCustomerOrderRequestValidator()
        {
            RuleFor(x => x.CustomerId).NotEmpty();
            RuleFor(x => x.ProductId).NotEmpty();
            RuleFor(x => x.CustomerId).NotEqual(x => x.ProductId);
        }
    }
}
