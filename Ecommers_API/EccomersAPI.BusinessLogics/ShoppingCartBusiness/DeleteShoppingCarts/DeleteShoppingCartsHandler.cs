using EccomersAPI.Repositories.Cart;
using EcommersAPI.Domain.Cart;
using MediatR;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EccomersAPI.BusinessLogics.ShoppingCartBusiness.DeleteShoppingCarts
{
    public class DeleteShoppingCartsHandler:IRequestHandler<DeleteShoppingCartsRequest,DeleteShoppingCartsResponse>
    {
        IMongoCollection<ShoppingCart> ShoppingCartCollection;
        CartRepository repository = null;
        public DeleteShoppingCartsHandler(EccomersAPI.Db.DatabaseDomain.Database db, CartRepository rez)
        {
            this.repository = rez;
            this.ShoppingCartCollection = db.GetCollection<ShoppingCart>("ShoppingCarts");
        }

        public async Task<DeleteShoppingCartsResponse> Handle(DeleteShoppingCartsRequest request, CancellationToken cancellationToken)
        {
            DeleteShoppingCartsResponse response=new DeleteShoppingCartsResponse();
            response.result=await this.repository.Delete(request.Id);
            return response;
        }
    }
}
