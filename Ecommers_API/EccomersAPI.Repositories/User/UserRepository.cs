using EccomersAPI.Db.DatabaseDomain;
using EcomersAPI.DataAbstraction;
using EcommersAPI.Domain.UserDomain;
using MongoDB.Driver;
namespace EccomersAPI.Repositories.UserRepository
{
    public class UserRepository : IRepository<User>
    {
        EccomersAPI.Db.DatabaseDomain.Database db = null;
        IMongoCollection<User> usersCollection;
        public UserRepository(EccomersAPI.Db.DatabaseDomain.Database database)
        {
            this.db = database;
            this.usersCollection = db.GetCollection<User>("Users");
        }
        public async Task<string> Create(User request)
        {
            await this.usersCollection.InsertOneAsync(request);
            return request.Id;
        }

        public async Task<bool> Delete(string Id)
        {
            var filtre = Builders<User>.Filter.Eq(x=>x.Id,Id);
            var response=await this.usersCollection.DeleteOneAsync(filtre);
            return response.DeletedCount!=0;
        }

        public async Task<List<User>> GetAll()
        {
            var filtre = Builders<User>.Filter.Empty;
            var response=await this.usersCollection.Find(filtre).ToListAsync();
            return response;
        }

        public async Task<User> GetById(string Id)
        {
            var filtre=Builders<User>.Filter.Eq(x=>x.Id, Id);
            var response= await this.usersCollection.Find(filtre).FirstOrDefaultAsync();
            return response;
        }

        public async Task<bool> Update(User entity)
        {
            var filtre = Builders<User>.Filter.Eq(x => x.Id,entity.Id);
            var update = Builders<User>.Update.Set(x => x.UserName, entity.UserName).Set(x => x.Email, entity.Email).Set(x => x.Password, entity.Password).Set(x => x.Name, entity.Name);
            var response = await this.usersCollection.UpdateOneAsync(filtre, update);
            return response.ModifiedCount!=0;
        }
    }
}
