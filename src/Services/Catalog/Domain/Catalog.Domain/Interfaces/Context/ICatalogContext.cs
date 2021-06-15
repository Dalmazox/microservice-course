using MongoDB.Driver;

namespace Catalog.Domain.Interfaces.Context
{
    public interface ICatalogContext
    {
        IMongoDatabase Database { get; }
    }
}
