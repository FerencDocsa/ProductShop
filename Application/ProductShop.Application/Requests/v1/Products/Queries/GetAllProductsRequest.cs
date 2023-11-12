using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using ProductShop.Domain.Entities.Product;
using ProductShop.Persistence.Abstractions.Repositories;

namespace ProductShop.Application.Requests.Products.Queries
{
    public class GetAllProductsRequest : IRequest<IEnumerable<Product>>
    { }

    public class GetAllProductsRequestHandler : IRequestHandler<GetAllProductsRequest, IEnumerable<Product>>
    {
        private readonly IProductRepository _productRepository;

        public GetAllProductsRequestHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<IEnumerable<Product>> Handle(GetAllProductsRequest request, CancellationToken cancellationToken)
        {
            return await _productRepository.GetAllProductsAsync();
        }
    }
}
