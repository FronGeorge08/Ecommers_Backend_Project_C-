using EccomersAPI.DataAbstraction.Database;
using EcommersAPI.Domain.ProductDomain;
using MediatR;
using MongoDB.Driver;

namespace EccomersAPI.BusinessLogics.Products.GetAllProducts
{
    public class GetAllProductsHandler : IRequestHandler<GetAllProductsRequest, GetAllProductsResponse>
    {
        IMongoCollection<Product> productsCollection;
        IProductRepository result = null;
        public GetAllProductsHandler(IDatabase db, IProductRepository rez)
        {
            this.result = rez;
            this.productsCollection = db.GetCollection<Product>();
        }
        public async Task<GetAllProductsResponse> Handle(GetAllProductsRequest request, CancellationToken cancellationToken)
        {
            GetAllProductsResponse response=new GetAllProductsResponse();
            response.products=await this.result.GetAll();
            return response;
        }
    }
}
