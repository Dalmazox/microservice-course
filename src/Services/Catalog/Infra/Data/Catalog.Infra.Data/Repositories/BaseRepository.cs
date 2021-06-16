using Catalog.Domain.Entities;
using Catalog.Domain.Interfaces.Context;
using Catalog.Domain.Interfaces.Repositories;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        Task<List<TEntity>> IRepository<TEntity>.List()
        {
            return _collection
                .Find(x => true)
                .ToListAsync();
        }

        public Task<TEntity> FindById(string id)
        {
            return _collection
                .Find(x => x.Id == id)
                .FirstOrDefaultAsync();
        }

        public Task<List<TEntity>> Find(FilterDefinition<TEntity> filter)
        {
            return _collection
                .Find(filter)
                .ToListAsync();
        }

        public Task Store(TEntity entity)
        {
            return _collection
                .InsertOneAsync(entity);
        }

        public async Task<bool> Update(TEntity entity)
        {
            var updateResult = await _collection
                .ReplaceOneAsync(x => x.Id == entity.Id, entity);

            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }

        public async Task<bool> Delete(string id)
        {
            var filter = Builders<TEntity>.Filter.Eq(x => x.Id, id);

            var deleteResult = await _collection
                .DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }
    }
}
