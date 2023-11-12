﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using ProductShop.Application.Exceptions;
using ProductShop.Domain.Entities.Product;
using ProductShop.Persistence.Abstractions.Repositories;

namespace ProductShop.Application.Requests.v1.Products.Queries
{
    public class GetProductByIdRequest : IRequest<Product>
    {
        [Required]
        public int Id { get; set; }
    }

    public class GetProductByIdRequestHandler : IRequestHandler<GetProductByIdRequest, Product>
    {
        private readonly IProductRepository _productRepository;

        public GetProductByIdRequestHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> Handle(GetProductByIdRequest request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsyncTask(request.Id, cancellationToken);

            if (product == null)
            {
                throw new ProductNotFoundException(request.Id);
            }

            return product;
        }
    }
}
