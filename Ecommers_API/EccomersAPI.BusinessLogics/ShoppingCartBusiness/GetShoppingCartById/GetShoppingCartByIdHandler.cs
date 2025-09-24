using EccomersAPI.DataAbstraction.Database;
using EcommersAPI.Domain.Cart;
using MediatR;
using MongoDB.Driver;

namespace EccomersAPI.BusinessLogics.ShoppingCartBusiness.GetShoppingCartById
{
    public class GetShoppingCartByIdHandler:IRequestHandler<GetShoppingCartByIdRequest,GetShoppingCartByIdResponse>
    {
        IMongoCollection<ShoppingCart> ShoppingCartCollection;
        ICartRepository repository = null;
        public GetShoppingCartByIdHandler(IDatabase db, ICartRepository rez)
        {
            this.repository = rez;
            this.ShoppingCartCollection = db.GetCollection<ShoppingCart>();
        }

        public async Task<GetShoppingCartByIdResponse> Handle(GetShoppingCartByIdRequest request, CancellationToken cancellationToken)
        {
            GetShoppingCartByIdResponse response =new GetShoppingCartByIdResponse();
            response.ShoppingCart=await this.repository.GetById(request.Id);
            return response;
        }
    }
}
