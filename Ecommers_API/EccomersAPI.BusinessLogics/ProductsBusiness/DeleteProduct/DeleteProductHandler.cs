using EccomersAPI.Repositories.ProductRepository;
using MediatR;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EcommersAPI.Domain.ProductDomain;
namespace EccomersAPI.BusinessLogics.Products.Delete
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductRequest, DeleteProductResponse>
    {
        IMongoCollection<Product> productsCollection;
        ProductRepository result = null;
        public DeleteProductHandler(EccomersAPI.Db.DatabaseDomain.Database db, ProductRepository rez)
        {
            this.result = rez;
            this.productsCollection = db.GetCollection<Product>("Products");
        }
        public async Task<DeleteProductResponse> Handle(DeleteProductRequest request, CancellationToken cancellationToken)
        {
            DeleteProductResponse Response=new DeleteProductResponse();
            Response.response=await this.result.Delete(request.Id);
            return Response;
        }
    }
}
