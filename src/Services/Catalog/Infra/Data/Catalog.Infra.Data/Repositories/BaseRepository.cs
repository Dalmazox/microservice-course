using Catalog.Domain.Entities;
using Catalog.Domain.Interfaces.Context;
using Catalog.Domain.Interfaces.Repositories;
using MongoDB.Driver;
using System.Collections.Generic;

namespace Catalog.Infra.Data.Repositories
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly ICatalogContext _context;
        protected readonly IMongoCollection<TEntity> _collection;

        protected BaseRepository(ICatalogContext context, string collectionName)
        {
            _context = context;
            _collection = _context.Database.GetCollection<TEntity>(collectionName);
        }

        public IEnumerable<TEntity> List()
        {
            return _collection.AsQueryable().ToList();
        }
    }
}
