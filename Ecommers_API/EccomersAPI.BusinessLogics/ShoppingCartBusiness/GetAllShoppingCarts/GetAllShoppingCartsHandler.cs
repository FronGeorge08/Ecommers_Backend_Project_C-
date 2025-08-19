using EccomersAPI.Repositories.Cart;
using EcommersAPI.Domain.Cart;
using MediatR;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EccomersAPI.BusinessLogics.ShoppingCartBusiness.GetAllShoppingCarts
{
    public class GetAllShoppingCartsHandler : IRequestHandler<GetAllShoppingCartsRequest, GetAllShoppingCartsResponse>
    {
        IMongoCollection<ShoppingCart> ShoppingCartCollection;
        CartRepository repository = null;
        public GetAllShoppingCartsHandler(EccomersAPI.Db.DatabaseDomain.Database db, CartRepository rez)
        {
            this.repository = rez;
            this.ShoppingCartCollection = db.GetCollection<ShoppingCart>("ShoppingCarts");
        }
        public async Task<GetAllShoppingCartsResponse> Handle(GetAllShoppingCartsRequest request, CancellationToken cancellationToken)
        {
            GetAllShoppingCartsResponse response = new GetAllShoppingCartsResponse();
            response.shoppingCarts=await this.repository.GetAll();
            return response;
        }
    }
}
