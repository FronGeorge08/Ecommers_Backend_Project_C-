using EccomersAPI.Db.DatabaseDomain;
using EcomersAPI.DataAbstraction;
using EcommersAPI.Domain.ProductDomain;
using EcommersAPI.Domain.UserDomain;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EccomersAPI.Repositories.ProductRepository
{
    public class ProductRepository : IRepository<Product>
    {
        EccomersAPI.Db.DatabaseDomain.Database db = null;
        IMongoCollection<Product> productCollection;
        public ProductRepository(EccomersAPI.Db.DatabaseDomain.Database database)
        {
            this.db = database;
            this.productCollection = db.GetCollection<Product>("Products");
        }
        public async Task<string> Create(Product entity)
        {
            await this.productCollection.InsertOneAsync(entity);
            return entity.Id;
        }

        public async Task<bool> Delete(string Id)
        {
            var filtre = Builders<Product>.Filter.Eq(x => x.Id, Id);
            var response = await this.productCollection.DeleteOneAsync(filtre);
            return response.DeletedCount != 0;
        }

        public async Task<List<Product>> GetAll()
        {
            var filtre = Builders<Product>.Filter.Empty;
            var response=await this.productCollection.Find(filtre).ToListAsync();
            return response;
        }
        public async Task<Product> GetById(string Id)
        {
            var filtre=Builders<Product>.Filter.Eq(x=>x.Id, Id);
            var response = await this.productCollection.Find(filtre).FirstOrDefaultAsync();
            return response;
        }

        public async Task<bool> Update(Product entity)
        {
            var filtre = Builders<Product>.Filter.Eq(x=>x.Id,entity.Id);
            var update = Builders<Product>.Update.Set(x=>x.Name,entity.Name).Set(x=>x.Quantity,entity.Quantity).Set(x=>x.Price,entity.Price).Set(x=>x.Brand,entity.Brand).Set(x=>x.Description,entity.Description);
            var response=await this.productCollection.UpdateOneAsync(filtre,update);
            return response.ModifiedCount != 0;
        }
    }
}
