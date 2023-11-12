using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductShop.Application.Requests.Products.Queries;
using ProductShop.Application.Requests.v1.Products.Queries;
using ProductShop.Domain.Entities.Product;

namespace ProductShop.WebAPI.Controllers.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    public class ProductsController : BaseController
    {
        public ProductsController(IMediator mediator) : base(mediator) { }

        [HttpGet]
        [Route("GetById")]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            var product = await _mediator.Send(new GetProductByIdRequest() { Id = id });
            return Ok(product);
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
        {
            var products = await _mediator.Send(new GetAllProductsRequest());
            return Ok(products);
        }
    }


}
