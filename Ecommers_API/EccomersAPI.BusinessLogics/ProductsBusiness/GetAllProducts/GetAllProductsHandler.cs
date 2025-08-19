using Amazon.Runtime.Internal;
using EccomersAPI.Repositories.ProductRepository;
using EcommersAPI.Domain.ProductDomain;
using MediatR;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EccomersAPI.BusinessLogics.Products.GetAllProducts
{
    public class GetAllProductsHandler : IRequestHandler<GetAllProductsRequest, GetAllProductsResponse>
    {
        IMongoCollection<Product> productsCollection;
        ProductRepository result = null;
        public GetAllProductsHandler(EccomersAPI.Db.DatabaseDomain.Database db, ProductRepository rez)
        {
            this.result = rez;
            this.productsCollection = db.GetCollection<Product>("Products");
        }
        public async Task<GetAllProductsResponse> Handle(GetAllProductsRequest request, CancellationToken cancellationToken)
        {
            GetAllProductsResponse response=new GetAllProductsResponse();
            response.products=await this.result.GetAll();
            return response;
        }
    }
}
