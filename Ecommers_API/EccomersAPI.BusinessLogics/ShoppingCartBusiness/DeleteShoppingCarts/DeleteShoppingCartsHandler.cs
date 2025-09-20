using EccomersAPI.DataAbstraction.Database;
using EccomersAPI.Repositories.Cart;
using EcomersAPI.DataAbstraction;
using EcommersAPI.Domain.Cart;
using EcommersAPI.Domain.UserDomain;
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
