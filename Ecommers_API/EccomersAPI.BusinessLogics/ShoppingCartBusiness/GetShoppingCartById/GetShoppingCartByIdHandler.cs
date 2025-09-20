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
