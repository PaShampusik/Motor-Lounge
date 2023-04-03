using MongoDB.Bson;
using MongoDB.Driver;
using Motor_Lounge.Services.MongoDB;

public class MongoDBService : IMongoDBService
{
    private readonly IMongoClient _client;
    private readonly IMongoDatabase _database;

    public MongoDBService(string connectionString, string databaseName)
    {
        _client = new MongoClient(connectionString);
        _database = _client.GetDatabase(databaseName);
    }

    public async Task<List<T>> GetAllAsync<T>()
    {
        var collection = _database.GetCollection<T>(typeof(T).Name);
        return await collection.Find(_ => true).ToListAsync();
    }

    public async Task<T> GetByIdAsync<T>(string id)
    {
        var collection = _database.GetCollection<T>(typeof(T).Name);
        var filter = Builders<T>.Filter.Eq("_id", ObjectId.Parse(id));
        return await collection.Find(filter).FirstOrDefaultAsync();
    }

    public async Task InsertAsync<T>(T item)
    {
        var collection = _database.GetCollection<T>(typeof(T).Name);
        await collection.InsertOneAsync(item);
    }

    public async Task UpdateAsync<T>(string id, T item)
    {
        var collection = _database.GetCollection<T>(typeof(T).Name);
        var filter = Builders<T>.Filter.Eq("_id", ObjectId.Parse(id));
        await collection.ReplaceOneAsync(filter, item);
    }

    public async Task DeleteAsync<T>(string id)
    {
        var collection = _database.GetCollection<T>(typeof(T).Name);
        var filter = Builders<T>.Filter.Eq("_id", ObjectId.Parse(id));
        await collection.DeleteOneAsync(filter);
    }
}