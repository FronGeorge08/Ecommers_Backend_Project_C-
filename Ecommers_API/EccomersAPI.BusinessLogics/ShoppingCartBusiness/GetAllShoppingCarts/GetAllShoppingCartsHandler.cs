using EccomersAPI.DataAbstraction.Database;
using EcommersAPI.Domain.Cart;
using MediatR;
using MongoDB.Driver;

namespace EccomersAPI.BusinessLogics.ShoppingCartBusiness.GetAllShoppingCarts
{
    public class GetAllShoppingCartsHandler : IRequestHandler<GetAllShoppingCartsRequest, GetAllShoppingCartsResponse>
    {
        IMongoCollection<ShoppingCart> ShoppingCartCollection;
        ICartRepository repository = null;
        public GetAllShoppingCartsHandler(IDatabase db, ICartRepository rez)
        {
            this.repository = rez;
            this.ShoppingCartCollection = db.GetCollection<ShoppingCart>();
        }
        public async Task<GetAllShoppingCartsResponse> Handle(GetAllShoppingCartsRequest request, CancellationToken cancellationToken)
        {
            GetAllShoppingCartsResponse response = new GetAllShoppingCartsResponse();
            response.shoppingCarts=await this.repository.GetAll();
            return response;
        }
    }
}
