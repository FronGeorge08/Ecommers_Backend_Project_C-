using EccomersAPI.DataAbstraction;
using EccomersAPI.DataAbstraction.Database;
using EccomersAPI.Database.Database;
using MongoDB.Driver;

namespace EccomersAPI.Db.DatabaseDomain
{
    public class Database:IDatabase
    {
        IMongoClient MongoClient { get; set; }
        IMongoDatabase MongoDatabase { get; set; }
        public Database(IDatabaseSettings settings) 
        {
            this.MongoClient= new MongoClient(settings.ConnectionString);
            this.MongoDatabase = MongoClient.GetDatabase(settings.Database);
        }
        public IMongoCollection <T> GetCollection <T>() where T : class
        {
            IMongoCollection<T> mongoCollection = this.MongoDatabase.GetCollection<T>(typeof(T).Name);
            return mongoCollection;
        }
    }
}
