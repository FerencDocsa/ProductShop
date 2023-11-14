using FluentValidation;

namespace ProductShop.Application.Requests.Products.Commands
{
    /// <summary>
    /// Example validator for request UpdateProductDescriptionRequest
    /// </summary>
    public class UpdateProductDescriptionRequestValidator : AbstractValidator<UpdateProductDescriptionRequest>
    {
        public UpdateProductDescriptionRequestValidator()
        {
            RuleFor(c => c.Description)
                .NotNull()
                .NotEmpty()
                .WithMessage("Description cannot be empty");

            RuleFor(c => c.Description)
                .MaximumLength(200)
                .WithMessage("The maximum length of description is 200 characters");

            RuleFor(c => c.ProductId)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage("ProductID must be provided");
        }
    }
}
