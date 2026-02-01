using BaseDomain.BaseItem;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EccomersAPI.BusinessLogics.ShoppingCartBusiness.GetShoppingCartById
{
    public class GetShoppingCartByIdRequest:IRequest<GetShoppingCartByIdResponse>
    {
        public string Id { get; set; }
        public GetShoppingCartByIdRequest() { }
    }
}
