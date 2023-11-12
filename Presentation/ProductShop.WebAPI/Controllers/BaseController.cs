using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ProductShop.WebAPI.Controllers
{
    //[Route("api/v{version:apiVersion}/[controller]")]
    //[ApiExplorerSettings(GroupName = "v1")]
    public class BaseController : Controller
    {
        public IMediator _mediator;

        public BaseController(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
