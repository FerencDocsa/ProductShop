﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductShop.Application.Requests.Products.Queries;
using ProductShop.Domain.Entities.Product;

namespace ProductShop.WebAPI.Controllers.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    public class ProductsController : BaseController
    {
        public ProductsController(IMediator mediator) : base(mediator) { }

        [HttpGet, MapToApiVersion("1.0")]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProductsAsync()
        {
            var products = await _mediator.Send(new GetAllProductsRequest());
            return Ok(products);
        }
    }


}