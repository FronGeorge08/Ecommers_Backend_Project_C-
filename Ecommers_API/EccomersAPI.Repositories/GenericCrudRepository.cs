using Amazon.Runtime.Internal;
using EccomersAPI.DataAbstraction;
using EccomersAPI.DataAbstraction.Database;
using EcomersAPI.DataAbstraction;
using EcommersAPI.Domain.UserDomain;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EccomersAPI.Repositories
{
    public class GenericCrudRepository<T> : IRepository<T>
        where T :class ,IContainsId 
    {
        IDatabase db;
        IMongoCollection<T> Collection;
        public GenericCrudRepository(IDatabase database)
        {
            this.db = database;
            this.Collection = db.GetCollection<T>();
        }
        public async Task<string> Create(T entity)
        {
            
            await this.Collection.InsertOneAsync(entity);
            return entity.Id;
        }

        public async Task<bool> Delete(string Id)
        {
            var filtre = Builders<T>.Filter.Eq(x => x.Id, Id);
            var response = await this.Collection.DeleteOneAsync(filtre);
            return response.DeletedCount != 0;
        }

        public async Task<List<T>> GetAll()
        {
            var filtre = Builders<T>.Filter.Empty;
            var response = await this.Collection.Find(filtre).ToListAsync();
            return response;
        }

        public async Task<T> GetById(string Id)
        {
            var filtre = Builders<T>.Filter.Eq(x => x.Id, Id);
            var response = await this.Collection.Find(filtre).FirstOrDefaultAsync();
            return response;
        }

        public async Task<bool> Update(T entity)
        {
            
            var filtre = Builders<T>.Filter.Eq(x => x.Id, entity.Id);
            var response = await this.Collection.ReplaceOneAsync(filtre,entity);
            return response.ModifiedCount != 0;
        }
    }
}
