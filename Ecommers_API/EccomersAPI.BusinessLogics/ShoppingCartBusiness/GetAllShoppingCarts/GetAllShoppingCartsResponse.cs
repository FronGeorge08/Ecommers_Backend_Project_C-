using EcommersAPI.Domain.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EccomersAPI.BusinessLogics.ShoppingCartBusiness.GetAllShoppingCarts
{
    public class GetAllShoppingCartsResponse
    {
        public List<ShoppingCart> shoppingCarts {  get; set; }
    }
}
