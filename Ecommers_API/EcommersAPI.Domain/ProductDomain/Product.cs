using BaseDomain.BaseProduct;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommersAPI.Domain.ProductDomain
{
    public class Product: BaseProduct
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        
        public Product(string name, string description, double price, int quantity, string brand):base(name, description, price, quantity, brand) 
        {
            this.Name = name;
            this.Brand = brand;
            this.Price = price;
            this.Quantity = quantity;
            this.Description = description;
        }
        public Product()
        {

        }
    }
}
