using BaseDomain.BaseItem;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EccomersAPI.BusinessLogics.ShoppingCartBusiness.UpdateShoppingCart
{
    public class UpdateShoppingCartRequest:BaseShoppingCart,IRequest<UpdateShoppingCartResponse>
    {
        public UpdateShoppingCartRequest() { }
        public UpdateShoppingCartRequest(UpdateShoppingCartRequest request)
        {
            this.UserId = request.UserId;
            this.Items= request.Items;
        }
        public UpdateShoppingCartRequest(string userId,List<BaseItem> items)
        {
            this.UserId = userId;   
            this.Items= items;
        }
    }
}
