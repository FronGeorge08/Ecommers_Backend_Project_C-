using MongoDB.Bson.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseDomain.BaseItem
{
    public class BaseShoppingCart
    {
        public string UserId { get; set; } 
        public List<BaseItem> Items { get; set; }
        public BaseShoppingCart ()
        {

        }
        public BaseShoppingCart(string userId)
        {
            UserId = userId;
            Items = new List<BaseItem>();
        }
        public BaseShoppingCart(BaseShoppingCart shoppingCart)
        {
            this.UserId = shoppingCart.UserId;
            this.Items = shoppingCart.Items;
        }
    }
}
