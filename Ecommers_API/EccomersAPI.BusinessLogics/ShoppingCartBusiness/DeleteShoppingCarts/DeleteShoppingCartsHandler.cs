using EccomersAPI.DataAbstraction.Database;
using EcommersAPI.Domain.Cart;
using MediatR;
using MongoDB.Driver;

namespace EccomersAPI.BusinessLogics.ShoppingCartBusiness.DeleteShoppingCarts
{
    public class DeleteShoppingCartsHandler:IRequestHandler<DeleteShoppingCartsRequest,DeleteShoppingCartsResponse>
    {
        IMongoCollection<ShoppingCart> ShoppingCartCollection;
        ICartRepository repository = null;
        public DeleteShoppingCartsHandler(IDatabase db, ICartRepository rez)
        {
            this.repository = rez;
            this.ShoppingCartCollection = db.GetCollection<ShoppingCart>();
        }

        public async Task<DeleteShoppingCartsResponse> Handle(DeleteShoppingCartsRequest request, CancellationToken cancellationToken)
        {
            DeleteShoppingCartsResponse response=new DeleteShoppingCartsResponse();
            response.result=await this.repository.Delete(request.Id);
            return response;
        }
    }
}
