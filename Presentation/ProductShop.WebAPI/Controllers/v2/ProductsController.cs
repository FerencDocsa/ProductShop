using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductShop.Application.Requests.Products.Queries;
using ProductShop.Domain.Entities.Product;

namespace ProductShop.WebAPI.Controllers.v2
{
    /// <summary>
    /// v2 controller for products 
    /// </summary>
    [ApiController]
    [ApiVersion("2.0")]
    public class ProductsController : BaseController
    {
        /// <summary>
        /// Just a constructor
        /// </summary>
        /// <param name="mediator"></param>
        public ProductsController(IMediator mediator) : base(mediator) { }

        /// <summary>
        /// Get paginated result of all products meeting provided params 
        /// </summary>
        /// <param name="page">Page of result</param>
        /// <param name="pageSize">Page size of result</param>
        /// <param name="searchBy">Search criteria (e.g. what we search for)</param>
        /// <param name="orderBy">Order by criteria (which column to order by name || description || price)</param>
        /// <param name="sortBy">Sort order for results (asc or desc)</param>
        /// <remarks>List of products</remarks>
        [HttpGet, MapToApiVersion("2.0")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status408RequestTimeout)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProductsAsync(string? searchBy, string? orderBy, string? sortBy, int page = 1, int pageSize = 10)
        {
            var products = await _mediator.Send(new GetAllProductsRequestPaged(page, pageSize, searchBy, orderBy, sortBy));
            return Ok(products);
        }
    }
}
