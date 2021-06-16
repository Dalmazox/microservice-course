using Catalog.Domain.Entities;
using Catalog.Domain.Interfaces.UoW;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalog.Application.API.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class CatalogController : ControllerBase
    {
        private readonly IUnitOfWork _uow;

        public CatalogController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Product>), StatusCodes.Status200OK)]
        public async Task<IActionResult> List()
        {
            return Ok(await _uow.Products.List());
        }

        [HttpGet("{id:length(24)}", Name = "GetProduct")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetProductById(string id)
        {
            var product = await _uow.Products.FindById(id);

            if (product is null)
                return NotFound();

            return Ok(product);
        }

        [HttpGet("category/{category}")]
        [ProducesResponseType(typeof(IEnumerable<Product>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetProductsByCategory(string category)
        {
            return Ok(await _uow.Products.FindByCategory(category));
        }

        [HttpPost]
        [ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
        public async Task<IActionResult> Store([FromBody] Product product)
        {
            await _uow.Products.Store(product);

            return CreatedAtRoute("GetProduct", new { id = product.Id }, product);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
        public async Task<IActionResult> Update([FromBody] Product product)
        {
            return Ok(await _uow.Products.Update(product));
        }

        [HttpDelete("{id:length(24)}", Name = "DeleteProduct")]
        [ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteProductById(string id)
        {
            return Ok(await _uow.Products.Delete(id));
        }
    }
}
