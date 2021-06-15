using Catalog.Domain.Entities;
using Catalog.Domain.Interfaces.Context;
using Catalog.Domain.Interfaces.Repositories;

namespace Catalog.Infra.Data.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(ICatalogContext context) : base(context, "products")
        { }
    }
}
