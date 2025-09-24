using EccomersAPI.DataAbstraction.Database;
using EcommersAPI.Domain.ProductDomain;
using MediatR;
using MongoDB.Driver;

namespace EccomersAPI.BusinessLogics.Products.Update
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductRequest, UpdateProductResponse>
    {
        IMongoCollection<Product> productsCollection;
        IProductRepository result = null;
        public UpdateProductHandler(IDatabase db, IProductRepository rez)
        {
            this.result = rez;
            this.productsCollection = db.GetCollection<Product>();
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
