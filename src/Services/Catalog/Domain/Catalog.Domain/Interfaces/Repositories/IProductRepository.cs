using Catalog.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalog.Domain.Interfaces.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<List<Product>> FindByName(string name);
        Task<List<Product>> FindByCategory(string category);
    }
}
