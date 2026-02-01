using EccomersAPI.DataAbstraction.Database;
using EcommersAPI.Domain.ProductDomain;
using MediatR;
using MongoDB.Driver;

namespace EccomersAPI.BusinessLogics.Products.GetById
{
    public class GetProductByIdHandler:IRequestHandler<GetProductByIdRequest,GetProductByIdResponse>
    {
        IMongoCollection<Product> productsCollection;
        IProductRepository result = null;
        public GetProductByIdHandler(IDatabase db, IProductRepository rez)
        {
            this.result = rez;
            this.productsCollection = db.GetCollection<Product>();
        }
        public async Task<GetProductByIdResponse> Handle(GetProductByIdRequest request, CancellationToken cancellationToken)
        {
            GetProductByIdResponse response = new GetProductByIdResponse();
            response.product=await this.result.GetById(request.Id);
            return response;
        }
    }
}
