using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BL.Students.Infrastructure.Data;

public sealed class MongoDbContext : IMongoDbContext
{
    public MongoDbContext(string connectionString, string databaseName)
    {
        Client = new MongoClient(connectionString);
        DatabaseName = databaseName;
        Database = Client.GetDatabase(DatabaseName);
    }

    public MongoDbContext(IOptions<MongoConnectionOptions> options)
    {
        var mongoOptions = options.Value;
        Client = new MongoClient(mongoOptions.ConnectionString);
        DatabaseName = mongoOptions.DatabaseName;
        Database = Client.GetDatabase(DatabaseName);
    }

    public IMongoClient Client { get; }
    public string DatabaseName { get; }
    public IMongoDatabase Database { get; }

    public bool CollectionExists<TType>()
    {
        var coll = Database.GetCollection<TType>(nameof(TType));
        return coll != null;
    }

    public IMongoCollection<TType> GetCollection<TType>(string collectionName)
    {
        return Database.GetCollection<TType>(collectionName);
    }
}
