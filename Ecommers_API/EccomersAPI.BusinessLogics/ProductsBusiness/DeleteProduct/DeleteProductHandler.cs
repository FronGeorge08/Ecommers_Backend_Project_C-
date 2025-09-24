using EccomersAPI.DataAbstraction.Database;
using EcommersAPI.Domain.ProductDomain;
using MediatR;
using MongoDB.Driver;
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
