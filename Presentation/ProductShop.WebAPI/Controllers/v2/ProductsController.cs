using MediatR;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProductsAsync(int page, int pageSize, string? searchBy, string? orderBy, string? sortBy)
        {
            var products = await _mediator.Send(new GetAllProductsRequestPaged(page, pageSize, searchBy, orderBy, sortBy));
            return Ok(products);
        }
    }
}
