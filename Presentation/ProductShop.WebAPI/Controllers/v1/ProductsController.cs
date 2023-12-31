﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductShop.Application.Requests.Products.Commands;
using ProductShop.Application.Requests.Products.Queries;
using ProductShop.Domain.Entities.Product;
using ProductShop.WebAPI.Requests;

namespace ProductShop.WebAPI.Controllers.v1
{
    /// <summary>
    /// Controller for Products
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    public class ProductsController : BaseController
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mediator">Dependency injection of Mediator</param>
        public ProductsController(IMediator mediator) : base(mediator)
        { }

        /// <summary>
        /// Get a product for provided ID
        /// </summary>
        /// <param name="id">ID of product to be found</param>
        /// <remarks>
        /// Returns product for provided ID or NotFound response
        /// </remarks>
        [HttpGet]
        [Route("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status408RequestTimeout)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            var product = await Mediator.Send(new GetProductByIdRequest() { Id = id });
            return Ok(product);
        }

        /// <summary>
        /// Get all products
        /// </summary>
        /// <remarks>List of products</remarks>>
        [HttpGet]
        [Route("GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status408RequestTimeout)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
        {
            var products = await Mediator.Send(new GetAllProductsRequest());
            return Ok(products);
        }

        /// <summary>
        /// Partially updates product with new description
        /// </summary>
        /// <param name="id">ID of product to update</param>
        /// <param name="request">Request consisting of new description</param>
        /// <remarks>Returns NoContent in case of successful update or response depending on error</remarks>
        [HttpPut]
        [Route("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status408RequestTimeout)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> UpdateProduct(int id, [FromBody] UpdateProductDescriptionRequestDto request)
        {
            await Mediator.Send(new UpdateProductDescriptionRequest()
                { ProductId = id, Description = request.Description });
            return NoContent();
        }
    }
}
