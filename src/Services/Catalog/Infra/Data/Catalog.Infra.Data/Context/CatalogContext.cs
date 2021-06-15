using Catalog.Domain.Interfaces.Context;
using Catalog.Domain.Options;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Catalog.Infra.Data.Context
{
    public class CatalogContext : ICatalogContext
    {
        private readonly DatabaseSettings _databaseSettings;
        private readonly MongoClient _client;
        private IMongoDatabase _database;

        public IMongoDatabase Database
        {
            get => _database ??= _client.GetDatabase(_databaseSettings.Database);
        }

        public CatalogContext(IOptions<DatabaseSettings> configuration)
        {
            _databaseSettings = configuration.Value;
            _client = new MongoClient(_databaseSettings.ConnectionString);
        }
    }
}
