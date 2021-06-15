using Catalog.Domain.Interfaces.Context;
using Catalog.Domain.Interfaces.Repositories;
using Catalog.Domain.Interfaces.UoW;
using Catalog.Infra.Data.Repositories;

namespace Catalog.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ICatalogContext _context;
        private IProductRepository _products;

        public IProductRepository Products => _products ??= new ProductRepository(_context);

        public UnitOfWork(ICatalogContext context)
        {
            _context = context;
        }
    }
}
