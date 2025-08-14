using EccomersAPI.Database.Database;
using MongoDB.Driver;

namespace EccomersAPI.Db.DatabaseDomain
{
    public class Database
    {
        IMongoClient MongoClient { get; set; }
        IMongoDatabase MongoDatabase { get; set; }
        public Database(DatabaseSettings settings) 
        {
            this.MongoClient= new MongoClient(settings.ConnectionString);
            this.MongoDatabase = MongoClient.GetDatabase(settings.Database);
        }
        public IMongoCollection <T> GetCollection <T>(string name) where T : class
        {
            IMongoCollection<T> mongoCollection = this.MongoDatabase.GetCollection<T>(name);
            return mongoCollection;
        }
    }
}
