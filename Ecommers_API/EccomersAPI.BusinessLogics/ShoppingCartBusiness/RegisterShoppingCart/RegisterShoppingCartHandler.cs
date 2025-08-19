using EccomersAPI.Repositories.Cart;
using EcommersAPI.Domain.Cart;
using MediatR;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EccomersAPI.BusinessLogics.ShoppingCartBusiness.RegisterShoppingCart
{
    public class RegisterShoppingCartHandler : IRequestHandler<RegisterShoppingCartRequest, RegisterShoppingCartResponse>
    {
        IMongoCollection<ShoppingCart> ShoppingCartCollection;
        CartRepository repository = null;
        public RegisterShoppingCartHandler(EccomersAPI.Db.DatabaseDomain.Database db, CartRepository rez)
        {
            this.repository = rez;
            this.ShoppingCartCollection = db.GetCollection<ShoppingCart>("ShoppingCarts");
        }
        public async Task<RegisterShoppingCartResponse> Handle(RegisterShoppingCartRequest request, CancellationToken cancellationToken)
        {
            ShoppingCart shop = new ShoppingCart();
            shop.Items = request.Items;
            shop.UserId=request.UserId;
            RegisterShoppingCartResponse response=new RegisterShoppingCartResponse();
            await this.repository.Create(shop);
            response.Id = shop.Id;
            return response;
        }
    }
}
