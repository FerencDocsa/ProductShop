using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ProductShop.WebAPI.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")] 
    public class BaseController : Controller
    {
        public IMediator _mediator;

        public BaseController(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
