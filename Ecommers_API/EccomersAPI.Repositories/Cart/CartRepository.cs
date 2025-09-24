using EccomersAPI.DataAbstraction.Database;
using EcomersAPI.DataAbstraction;
using EcommersAPI.Domain.Cart;
using EcommersAPI.Domain.ProductDomain;
using EcommersAPI.Domain.UserDomain;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EccomersAPI.Repositories.Cart
{
    public class CartRepository : GenericCrudRepository<ShoppingCart>, ICartRepository
    {
        IDatabase db;
        IMongoCollection<ShoppingCart> CartCollection;
        public CartRepository(IDatabase data):base(data) 
        {
            this.db = data;
            this.CartCollection = data.GetCollection<ShoppingCart>();
        }
    }
}
