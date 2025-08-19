using EccomersAPI.Repositories.ProductRepository;
using EcommersAPI.Domain.ProductDomain;
using MediatR;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EccomersAPI.BusinessLogics.Products.Update
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductRequest, UpdateProductResponse>
    {
        IMongoCollection<Product> productsCollection;
        ProductRepository result = null;
        public UpdateProductHandler(EccomersAPI.Db.DatabaseDomain.Database db, ProductRepository rez)
        {
            this.result = rez;
            this.productsCollection = db.GetCollection<Product>("Products");
        }
        public async Task<UpdateProductResponse> Handle(UpdateProductRequest request, CancellationToken cancellationToken)
        {
            Product product = new Product();
            product.Name = request.Name;
            product.Description = request.Description;
            product.Price = request.Price;
            product.Id = request.Id;
            product.Quantity= request.Quantity;
            product.Brand = request.Brand;  
            UpdateProductResponse response=new UpdateProductResponse();
            response.result=await this.result.Update(product);
            return response;
            
        }
    }
}
