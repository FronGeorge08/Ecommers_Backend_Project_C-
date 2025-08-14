using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseDomain.BaseItem
{
    public class BaseItem
    {
        public string ProductId { get; set; }
        public int ProductQuantity { get; set; }
        public BaseItem() { }
        public BaseItem(string productId, int productQuantity)
        {
            this.ProductId = productId;
            this.ProductQuantity = productQuantity;
        }
        public BaseItem(BaseItem item)
        {
            this.ProductQuantity= item.ProductQuantity;
            this.ProductId = item.ProductId;
        }
    }
}
