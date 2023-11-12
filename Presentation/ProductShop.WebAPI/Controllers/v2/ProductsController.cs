using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductShop.Application.Requests.Products.Queries;
using ProductShop.Application.Requests.v2.Products.Queries;
using ProductShop.Domain.Entities.Product;

namespace ProductShop.WebAPI.Controllers.v2
{
    [ApiController]
    [ApiVersion("2.0")]
    public class ProductsController : BaseController
    {
        public ProductsController(IMediator mediator) : base(mediator) { }

        [HttpGet, MapToApiVersion("2.0")]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProductsAsync(int page, int pageSize)
        {
            var products = await _mediator.Send(new GetAllProductsRequestPaged(page, pageSize));
            return Ok(products);
        }
    }
}
