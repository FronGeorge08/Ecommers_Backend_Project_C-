using EccomersAPI.DataAbstraction.Database;
using EccomersAPI.Db.DatabaseDomain;
using EcomersAPI.DataAbstraction;
using EcommersAPI.Domain.UserDomain;
using MongoDB.Driver;
namespace EccomersAPI.Repositories.UserRepository
{
    public class UserRepository : GenericCrudRepository<User>,IUserRepository
    {
        IDatabase db;
        IMongoCollection<User> usersCollection;
        public UserRepository(IDatabase database):base(database) 
        {
            this.db = database;
            this.usersCollection = db.GetCollection<User>();
        }
        public async Task<User> GetEmail(string email)
        {
            var filtre = Builders<User>.Filter.Eq(x => x.Email, email);
            var response = await this.usersCollection.Find(filtre).FirstOrDefaultAsync();
            return response;
        }
    }
}
