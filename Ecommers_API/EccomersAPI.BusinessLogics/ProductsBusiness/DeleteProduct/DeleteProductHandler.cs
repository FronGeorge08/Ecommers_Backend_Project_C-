using EccomersAPI.DataAbstraction.Database;
using EccomersAPI.Repositories.ProductRepository;
using EcomersAPI.DataAbstraction;
using EcommersAPI.Domain.Cart;
using EcommersAPI.Domain.ProductDomain;
using MediatR;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EccomersAPI.BusinessLogics.Products.Delete
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductRequest, DeleteProductResponse>
    {
        IMongoCollection<Product> productsCollection;
        IProductRepository result = null;
        public DeleteProductHandler(IDatabase db, IProductRepository rez)
        {
            this.result = rez;
            this.productsCollection = db.GetCollection<Product>();
        }
        public async Task<DeleteProductResponse> Handle(DeleteProductRequest request, CancellationToken cancellationToken)
        {
            DeleteProductResponse Response=new DeleteProductResponse();
            Response.response=await this.result.Delete(request.Id);
            return Response;
        }
    }
}
