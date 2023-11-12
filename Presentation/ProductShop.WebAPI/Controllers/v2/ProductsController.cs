using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductShop.Application.Requests.Products.Queries;
using ProductShop.Domain.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductShop.WebAPI.Controllers.v2
{
    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ProductsController : BaseController
    {
        public ProductsController(IMediator mediator) : base(mediator) { }

        [HttpGet, MapToApiVersion("2.0")]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProductsAsync()
        {
            var products = await _mediator.Send(new GetAllProductsRequest());
            return Ok(products);
        }
    }
}
