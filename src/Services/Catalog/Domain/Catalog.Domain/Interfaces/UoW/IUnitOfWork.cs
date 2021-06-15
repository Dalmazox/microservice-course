using Catalog.Domain.Interfaces.Repositories;

namespace Catalog.Domain.Interfaces.UoW
{
    public interface IUnitOfWork
    {
        IProductRepository Products { get; }
    }
}