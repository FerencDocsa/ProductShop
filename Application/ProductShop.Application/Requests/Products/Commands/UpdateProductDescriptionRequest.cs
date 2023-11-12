using System.ComponentModel.DataAnnotations;
using MediatR;
using ProductShop.Application.Exceptions;
using ProductShop.Persistence.Abstractions.Repositories;

namespace ProductShop.Application.Requests.v1.Products.Commands
{
    public class UpdateProductDescriptionRequest : IRequest
    {
        [Required]
        public int ProductId { get; set; }

        [Required]
        public string Description { get; set; } = string.Empty;
    }

    public class UpdateProductDescriptionRequestHandler : IRequestHandler<UpdateProductDescriptionRequest>
    {
        private readonly IProductRepository _repository;

        public UpdateProductDescriptionRequestHandler(IProductRepository repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateProductDescriptionRequest request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetByIdAsync(request.ProductId, cancellationToken);

            if (product is null)
            {
                throw new ProductNotFoundException(request.ProductId);
            }

            _repository.UpdateProductDescriptionAsync(product, request.Description);
        }
    }
}
