using BaseDomain.BaseItem;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommersAPI.Domain.Cart
{
    public class ShoppingCart:BaseShoppingCart
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public ShoppingCart() { }
        public ShoppingCart(string userId)
        {
            this.UserId = userId;
            this.Items = new List<BaseItem>();
        }
        public ShoppingCart(ShoppingCart shoppingCart)
        {
            this.UserId= shoppingCart.UserId;  
            this.Items =shoppingCart.Items;
        }
        public ShoppingCart(BaseShoppingCart shoppingCart)
        {
            this.UserId=(shoppingCart.UserId);
            this.Items = shoppingCart.Items;
        }
        public ShoppingCart(BaseShoppingCart shop,int a)
        {
            this.UserId=shop.UserId;
            this.Items = new List<BaseItem>();
        }
    }
}
