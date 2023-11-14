using FluentValidation;

namespace ProductShop.Application.Requests.Products.Queries
{
    public class GetAllProductsRequestPagedValidator : AbstractValidator<GetAllProductsRequestPaged>
    {
        public GetAllProductsRequestPagedValidator()
        {
            RuleFor(c => c.Page)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage("Page number should be greater than Zero");

            RuleFor(c => c.PageSize)
                .NotNull()
                .NotEmpty()
                .GreaterThanOrEqualTo(0)
                .WithMessage("Page size should be greater or equal Zero");
        }
    }
}
