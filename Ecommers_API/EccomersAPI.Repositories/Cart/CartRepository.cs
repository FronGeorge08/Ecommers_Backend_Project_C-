using EcomersAPI.DataAbstraction;
using EcommersAPI.Domain.Cart;
using EcommersAPI.Domain.ProductDomain;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EccomersAPI.Repositories.Cart
{
    public class CartRepository : IRepository<ShoppingCart>
    {
        EccomersAPI.Db.DatabaseDomain.Database db = null;
        IMongoCollection<ShoppingCart> CartCollection;
        public CartRepository(EccomersAPI.Db.DatabaseDomain.Database database)
        {
            this.db = database;
            this.CartCollection = db.GetCollection<ShoppingCart>("ShoppingCarts");
        }
        public async Task<string> Create(ShoppingCart entity)
        {
            await this.CartCollection.InsertOneAsync(entity);
            return entity.Id;
        }

        public async Task<bool> Delete(string Id)
        {
            var filtre = Builders<ShoppingCart>.Filter.Eq(x => x.Id, Id);
            var response = await this.CartCollection.DeleteOneAsync(filtre);
            return response.DeletedCount != 0;
        }

        public async Task<List<ShoppingCart>> GetAll()
        {
            var filtre = Builders<ShoppingCart>.Filter.Empty;
            var response = await this.CartCollection.Find(filtre).ToListAsync();
            return response;
        }

        public async Task<ShoppingCart> GetById(string Id)
        {
            var filtre = Builders<ShoppingCart>.Filter.Eq(x => x.Id, Id);
            var response = await this.CartCollection.Find(filtre).FirstOrDefaultAsync();
            return response;
        }

        public async Task<bool> Update(ShoppingCart entity)
        {
            var filtre = Builders<ShoppingCart>.Filter.Eq(x => x.Id, entity.Id);
            var update = Builders<ShoppingCart>.Update.Set(x => x.Id, entity.Id).Set(x => x.UserId, entity.UserId).Set(x => x.Items, entity.Items);
            var response = await this.CartCollection.UpdateOneAsync(filtre, update);
            return response.ModifiedCount != 0;
        }
    }
}
