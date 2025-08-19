using EccomersAPI.Repositories.Cart;
using EcommersAPI.Domain.Cart;
using MediatR;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EccomersAPI.BusinessLogics.ShoppingCartBusiness.GetShoppingCartById
{
    public class GetShoppingCartByIdHandler:IRequestHandler<GetShoppingCartByIdRequest,GetShoppingCartByIdResponse>
    {
        IMongoCollection<ShoppingCart> ShoppingCartCollection;
        CartRepository repository = null;
        public GetShoppingCartByIdHandler(EccomersAPI.Db.DatabaseDomain.Database db, CartRepository rez)
        {
            this.repository = rez;
            this.ShoppingCartCollection = db.GetCollection<ShoppingCart>("ShoppingCarts");
        }

        public async Task<GetShoppingCartByIdResponse> Handle(GetShoppingCartByIdRequest request, CancellationToken cancellationToken)
        {
            GetShoppingCartByIdResponse response =new GetShoppingCartByIdResponse();
            response.ShoppingCart=await this.repository.GetById(request.Id);
            return response;
        }
    }
}
