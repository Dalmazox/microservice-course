using Catalog.Domain.Entities;

namespace Catalog.Domain.Interfaces.Repositories
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        System.Collections.Generic.IEnumerable<TEntity> List();
    }
}
