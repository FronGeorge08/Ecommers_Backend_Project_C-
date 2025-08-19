using BaseDomain.BaseItem;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EccomersAPI.BusinessLogics.ShoppingCartBusiness.RegisterShoppingCart
{
    public class RegisterShoppingCartRequest:BaseShoppingCart,IRequest<RegisterShoppingCartResponse>
    {
        public RegisterShoppingCartRequest() { }    
        public RegisterShoppingCartRequest(string userId,List<BaseItem> items)
        {
            this.UserId = userId;
            this.Items = items;
        }
        public RegisterShoppingCartRequest(RegisterShoppingCartRequest cart)
        {
            this.Items=cart.Items;
            this.UserId=cart.UserId;    
        }
    }
}
