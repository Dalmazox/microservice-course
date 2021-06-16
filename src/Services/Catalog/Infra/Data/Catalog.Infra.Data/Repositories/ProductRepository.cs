using Catalog.Domain.Entities;
using Catalog.Domain.Interfaces.Context;
using Catalog.Domain.Interfaces.Repositories;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalog.Infra.Data.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(ICatalogContext context) : base(context, "products")
        { }

        public Task<List<Product>> FindByCategory(string category)
        {
            var filter = Builders<Product>.Filter.Eq(x => x.Category, category);

            return Find(filter);
        }

        public Task<List<Product>> FindByName(string name)
        {
            var filter = Builders<Product>.Filter.Eq(x => x.Name, name);

            return Find(filter);
        }
    }
}
