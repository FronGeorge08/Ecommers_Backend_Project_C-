using EccomersAPI.BusinessLogics.Products.Delete;
using EccomersAPI.BusinessLogics.Products.GetAllProducts;
using EccomersAPI.BusinessLogics.Products.GetById;
using EccomersAPI.BusinessLogics.Products.Register;
using EccomersAPI.BusinessLogics.Products.Update;
using EccomersAPI.BusinessLogics.ProductsBusiness.GetProductById;
using EccomersAPI.BusinessLogics.UsersBusiness.GetUserById;
using EccomersAPI.DataAbstraction.Database;
using EccomersAPI.Db.DatabaseDomain;
using EccomersAPI.Repositories.ProductRepository;
using EcomersAPI.DataAbstraction;
using EcommersAPI.Domain.ProductDomain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Driver;
namespace Ecommers_API.Controllers

{
    [ApiController]
    [Route("[controller]")]
    public class ProductController: ControllerBase
    {
        IMediator mediator;
        public ProductController(IMediator med)
        {
            this.mediator = med;
        }

        [HttpPost("CreateProduct")]
        public async Task<string> CreateProduct(RegisterProductRequest request)
        {
            RegisterProductResponse response=await this.mediator.Send(request);
            return response.ProductId;  
        }
        [HttpGet("GetProductById/{Id}")]
        public async Task<IActionResult> GetProductById(string Id)
        {
            GetProductByIdRequest request=new GetProductByIdRequest();
            request.Id=Id;
            var validator = new GetProductByIdValidator();
            var validationResult = validator.Validate(request);

            if (validationResult.IsValid == false)
            {
                var errorList = validationResult.Errors.Select(e => new
                {
                    field = e.PropertyName,
                    message = e.ErrorMessage
                });
                return this.BadRequest(errorList);
            }
            GetProductByIdResponse response = await this.mediator.Send(request);
            return this.Ok(response.product);
        }
        [HttpGet("GetAllProducts")]
        public async Task<List<Product>> GetAllProducts()
        {
            GetAllProductsRequest request=new GetAllProductsRequest();
            GetAllProductsResponse response=await this.mediator.Send(request);
            return response.products;
        }
        [HttpPut("UpdateProduct")]
        public async Task<bool> UpdateProduct(UpdateProductRequest request)
        {
            UpdateProductResponse response= await this.mediator.Send(request);
            return response.result;
        }
        [HttpDelete("DeleteProduct")]
        public async Task<bool> DeleteProduct(DeleteProductRequest request)
        {
            DeleteProductResponse response=await this.mediator.Send(request);
            return response.response;
        }
    }
}
