using EccomersAPI.Repositories.Cart;
using EcommersAPI.Domain.Cart;
using MediatR;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EccomersAPI.BusinessLogics.ShoppingCartBusiness.UpdateShoppingCart
{
    public class UpdateShoppingCartHandler : IRequestHandler<UpdateShoppingCartRequest, UpdateShoppingCartResponse>
    {
        IMongoCollection<ShoppingCart> ShoppingCartCollection;
        CartRepository repository = null;
        public UpdateShoppingCartHandler(EccomersAPI.Db.DatabaseDomain.Database db, CartRepository rez)
        {
            this.repository = rez;
            this.ShoppingCartCollection = db.GetCollection<ShoppingCart>("ShoppingCarts");
        }
        public async Task<UpdateShoppingCartResponse> Handle(UpdateShoppingCartRequest request, CancellationToken cancellationToken)
        {
            ShoppingCart shop = new ShoppingCart();
            shop.UserId = request.UserId;
            shop.Items= request.Items;
            UpdateShoppingCartResponse response=new UpdateShoppingCartResponse();
            response.result=await this.repository.Update(shop);
            return response;
        }
    }
}
