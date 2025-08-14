using Microsoft.AspNetCore.Mvc;
using EcommersAPI.Domain.ProductDomain;
using EcommersAPI.Domain.UserDomain;
using MongoDB.Driver;
using EccomersAPI.Db.DatabaseDomain;
using EccomersAPI.CommonDomain.Products;
using EccomersAPI.Repositories.UserRepository;
using EccomersAPI.Repositories.ProductRepository;
using MongoDB.Bson.Serialization.IdGenerators;
namespace Ecommers_API.Controllers

{
    [ApiController]
    [Route("[controller]")]
    public class ProductController: ControllerBase
    {
        IMongoCollection<Product> productsCollection;
        ProductRepository result = null;
        public ProductController(Database db,ProductRepository rez)
        {
            this.result= rez;
            this.productsCollection=db.GetCollection<Product>("Products");
        }

        [HttpPost("CreateProduct")]
        public async Task<string> CreateProduct(CreateProductRequestDTO request)
        {
            Product product = new Product(request);
            return await this.result.Create(product);
        }
        [HttpGet("GetProductById")]
        public async Task<Product> Get_Product_By_Id(string Id)
        {
            return await this.result.GetById(Id);
        }
        [HttpGet("GetAllProducts")]
        public async Task<List<Product>> Get_All_Products()
        {  
            return await this.result.GetAll();   
        }
        [HttpPut("UpdateProduct")]
        public async Task<bool> Update_Product(string Id,UpdateProductRequestDTO request)
        {
            Product product=new Product(request);
            product.Id = Id;
            return await this.result.Update(product);
        }
        [HttpDelete("DeleteProduct")]
        public async Task<bool> Delete_Product(string Id)
        {
            return await this.result.Delete(Id);
        }
    }
}
