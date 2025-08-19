using EccomersAPI.Repositories.ProductRepository;
using EcommersAPI.Domain.ProductDomain;
using MediatR;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EccomersAPI.BusinessLogics.Products.Register
{
    public class RegisterProductHandler : IRequestHandler<RegisterProductRequest, RegisterProductResponse>
    {
        IMongoCollection<Product> productsCollection;
        ProductRepository result = null;
        public RegisterProductHandler(EccomersAPI.Db.DatabaseDomain.Database db, ProductRepository rez)
        {
            this.result = rez;
            this.productsCollection = db.GetCollection<Product>("Products");
        }
        public async Task<RegisterProductResponse> Handle(RegisterProductRequest request, CancellationToken cancellationToken)
        {
            Product product = new Product();
            product.Name = request.Name;
            product.Description = request.Description;
            product.Price = request.Price;
            product.Brand = request.Brand;
            product.Quantity = request.Quantity;
            await this.result.Create(product);
            RegisterProductResponse response=new RegisterProductResponse();
            response.ProductId=product.Id;
            return response;
        }
    }
}
