using EccomersAPI.DataAbstraction.Database;
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
    public class ProductRepository :GenericCrudRepository<Product>,IProductRepository
    {
        IDatabase db;
        IMongoCollection<Product> productCollection;
        public ProductRepository(IDatabase database):base(database) 
        {
            this.db = database;
            this.productCollection =database.GetCollection<Product>();
        }
    }
}
