using BaseDomain.BaseItem;
using EccomersAPI.BusinessLogics.ShoppingCartBusiness.DeleteShoppingCarts;
using EccomersAPI.BusinessLogics.ShoppingCartBusiness.GetAllShoppingCarts;
using EccomersAPI.BusinessLogics.ShoppingCartBusiness.GetShoppingCartById;
using EccomersAPI.BusinessLogics.ShoppingCartBusiness.RegisterShoppingCart;
using EccomersAPI.BusinessLogics.ShoppingCartBusiness.UpdateShoppingCart;
using EccomersAPI.BusinessLogics.UsersBusiness.GetUserById;
using EccomersAPI.CommonDomain.Users;
using EccomersAPI.DataAbstraction.Database;
using EccomersAPI.Db.DatabaseDomain;
using EccomersAPI.Repositories.Cart;
using EccomersAPI.Repositories.UserRepository;
using EcomersAPI.DataAbstraction;
using EcommersAPI.Domain.Cart;
using EcommersAPI.Domain.ProductDomain;
using EcommersAPI.Domain.UserDomain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace Ecommers_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShoppingCartController: ControllerBase
    {
        
        IMediator mediator;
        public ShoppingCartController(IMediator med)
        {
            this.mediator = med;
        }
        [HttpPost("CreateShoppingCart")]
        public async Task<string> CreateShoppingCart(RegisterShoppingCartRequest request)
        {
            RegisterShoppingCartResponse response=await this.mediator.Send(request);
            return response.Id;
        }
        [HttpDelete("DeleteShoppingCart")]
        public async Task<bool> DeleteShoppingCart(DeleteShoppingCartsRequest request)
        {
            DeleteShoppingCartsResponse response = await this.mediator.Send(request);
            return response.result;
        }
        [HttpPut("UpdateShoppingCart")]
        public async Task<bool> UpdateShoppingCart(UpdateShoppingCartRequest request)
        {
            UpdateShoppingCartResponse response = await this.mediator.Send(request);
            return response.result;
        }
        [HttpGet("GetShoppingCartById/{Id}")]
        public async Task<IActionResult> GetShoppingCartbyId(string Id)
        {
            GetShoppingCartByIdRequest request=new GetShoppingCartByIdRequest();
            request.Id=Id;
            var validator = new GetShoppingCartByIdValidator();
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
            GetShoppingCartByIdResponse response= await this.mediator.Send(request);    
            return this.Ok(response.ShoppingCart);
        }
        [HttpGet("GetAllShoppingCarts")]
        public async Task<List<ShoppingCart>> GetAllShoppingCarts()
        {
            GetAllShoppingCartsRequest request=new GetAllShoppingCartsRequest();
            GetAllShoppingCartsResponse response= await this.mediator.Send(request);
            return response.shoppingCarts;
        }
    }
}
