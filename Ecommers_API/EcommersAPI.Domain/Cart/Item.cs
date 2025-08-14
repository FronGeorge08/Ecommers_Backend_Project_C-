using BaseDomain.BaseItem;
using EccomersAPI.Db.DatabaseDomain;
using EcommersAPI.Domain.ProductDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommersAPI.Domain.Cart
{
    public class Item:BaseItem
    {
        public Item() { }   
        public Item(string productId, int productQuantity) : base(productId, productQuantity)
        {
            this.ProductId=productId;
            this.ProductQuantity=productQuantity;
        }
        public Item(Item item)
        {
            this.ProductId = item.ProductId;
            this.ProductQuantity = item.ProductQuantity;
        }
        public Item(BaseItem item) 
        {
            this.ProductId = item.ProductId;
            this.ProductQuantity = item.ProductQuantity;
        }
    }
}
