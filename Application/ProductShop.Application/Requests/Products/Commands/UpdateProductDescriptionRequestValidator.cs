using FluentValidation;
using ProductShop.Application.Requests.v1.Products.Commands;

namespace ProductShop.Application.Requests.Products.Commands
{
    /// <summary>
    /// Example validator for request UpdateProductDescriptionRequest
    /// </summary>
    internal class UpdateProductDescriptionRequestValidator : AbstractValidator<UpdateProductDescriptionRequest>
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
                .WithMessage("ProductID must be provided");
        }
    }
}
