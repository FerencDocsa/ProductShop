using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductShop.Application.Exceptions;
using ProductShop.Application.Requests.Products.Queries;
using ProductShop.Application.Requests.v1.Products.Commands;
using ProductShop.Application.Requests.v1.Products.Queries;
using ProductShop.Domain.Entities.Product;
using ProductShop.Persistence.Exceptions;
using ProductShop.WebAPI.Requests;

namespace ProductShop.WebAPI.Controllers.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    public class ProductsController : BaseController
    {
        public ProductsController(IMediator mediator) : base(mediator) { }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            try
            {
                var product = await _mediator.Send(new GetProductByIdRequest() { Id = id });
                return Ok(product);
            }
            catch (ProductNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
        {
            var products = await _mediator.Send(new GetAllProductsRequest());
            return Ok(products);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult> UpdateProduct(int id, [FromBody] UpdateProductDescriptionRequestDto request)
        {
            try
            {
                await _mediator.Send(new UpdateProductDescriptionRequest() { ProductId = id, Description = request.Description });
                return NoContent();
            }
            catch (ProductNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (ProductUpdateException e)
            {
                return BadRequest(e.Message);
            }
        }
    }


}
