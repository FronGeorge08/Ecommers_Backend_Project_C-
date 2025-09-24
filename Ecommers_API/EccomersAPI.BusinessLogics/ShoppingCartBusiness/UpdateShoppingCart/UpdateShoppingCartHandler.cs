using EccomersAPI.DataAbstraction.Database;
using EcommersAPI.Domain.Cart;
using MediatR;
using MongoDB.Driver;

namespace EccomersAPI.BusinessLogics.ShoppingCartBusiness.UpdateShoppingCart
{
    public class UpdateShoppingCartHandler : IRequestHandler<UpdateShoppingCartRequest, UpdateShoppingCartResponse>
    {
        IMongoCollection<ShoppingCart> ShoppingCartCollection;
        ICartRepository repository = null;
        public UpdateShoppingCartHandler(IDatabase db, ICartRepository rez)
        {
            this.repository = rez;
            this.ShoppingCartCollection = db.GetCollection<ShoppingCart>();
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
