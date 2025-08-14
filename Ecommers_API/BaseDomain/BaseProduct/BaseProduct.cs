using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseDomain.BaseProduct
{
    public class BaseProduct
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string Brand { get; set; }
        public BaseProduct(string name,string description,double price,int quantity,string brand)
        {
            this.Name = name;
            this.Description = description;
            this.Price = price;
            this.Quantity = quantity;
            this.Brand = brand;
        }
        public BaseProduct() { }
    }
}
