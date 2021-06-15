using Catalog.Domain.Interfaces.UoW;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Application.API.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class ProductsController : ControllerBase
    {
        [HttpGet("")]
        public IActionResult List([FromServices] IUnitOfWork uow)
        {
            return Ok(uow.Products.List());
        }
    }
}
