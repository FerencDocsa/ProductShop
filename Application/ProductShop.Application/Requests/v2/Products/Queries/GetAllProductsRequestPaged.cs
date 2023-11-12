using MediatR;
using ProductShop.Domain.Entities.Product;
using ProductShop.Persistence.Abstractions.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductShop.Application.Requests.v2.Products.Queries
{
    public class GetAllProductsRequestPaged : IRequest<IEnumerable<Product>>
    {
        [Required]
        public int Page { get; }

        [Required]
        public int PageSize { get; }

        public GetAllProductsRequestPaged(int page, int pageSize)
        {
            Page = page;
            PageSize = pageSize;
        }
    }

    public class GetAllProductsRequestPagedHandler : IRequestHandler<GetAllProductsRequestPaged, IEnumerable<Product>>
    {
        private readonly IProductRepository _productRepository;

        public GetAllProductsRequestPagedHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> Handle(GetAllProductsRequestPaged request, CancellationToken cancellationToken)
        {
            return await _productRepository.GetAllProductsPagedAsync(request.Page, request.PageSize);
        }
    }
}
