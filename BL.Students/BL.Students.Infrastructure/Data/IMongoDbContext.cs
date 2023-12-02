using MongoDB.Driver;

namespace BL.Students.Infrastructure.Data;

public interface IMongoDbContext
{
    IMongoClient Client { get; }
    IMongoDatabase Database { get; }

    string DatabaseName { get; }

    bool CollectionExists<TType>();

    IMongoCollection<TType> GetCollection<TType>(string collectionName);
}
