using MongoDB.Driver;

namespace MongoDbLearning.Data;

public class AppDataContext
{
    private readonly MongoClient _mongoClient = new("mongodb://localhost:27017");

    public IMongoDatabase GetDatabaseByName(string databaseName)
    {
        return _mongoClient.GetDatabase(databaseName);
    }
}