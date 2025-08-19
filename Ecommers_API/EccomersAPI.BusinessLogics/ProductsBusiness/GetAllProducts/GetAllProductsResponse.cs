using EcommersAPI.Domain.ProductDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EccomersAPI.BusinessLogics.Products.GetAllProducts
{
    public class GetAllProductsResponse
    {
        public List<Product> products {  get; set; }
    }
}
