﻿using MediatR;
using ProductShop.Domain.Entities.Product;
using ProductShop.Persistence.Abstractions.Repositories;
using System.ComponentModel.DataAnnotations;

namespace ProductShop.Application.Requests.v2.Products.Queries
{
    public class GetAllProductsRequestPaged : IRequest<IEnumerable<Product>>
    {
        [Required]
        public int Page { get; }

        [Required]
        public int PageSize { get; }

        public string? SearchBy { get; }

        public string? OrderBy { get; }

        public string? SortBy { get; }

        public GetAllProductsRequestPaged(int page, int pageSize, string? searchBy, string? orderBy, string? sortBy)
        {
            Page = page;
            PageSize = pageSize;
            SearchBy = searchBy;
            OrderBy = orderBy;
            SortBy = sortBy;
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
            return await _productRepository.GetAllProductsPagedAsync(request.Page, request.PageSize, request.SearchBy, request.OrderBy, request.SortBy);
        }
    }
}
