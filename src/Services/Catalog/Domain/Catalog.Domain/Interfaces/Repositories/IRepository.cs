using Catalog.Domain.Entities;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalog.Domain.Interfaces.Repositories
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        Task<List<TEntity>> List();
        Task<TEntity> FindById(string id);
        Task<List<TEntity>> Find(FilterDefinition<TEntity> filter);
        Task Store(TEntity entity);
        Task<bool> Update(TEntity entity);
        Task<bool> Delete(string id);
    }
}
