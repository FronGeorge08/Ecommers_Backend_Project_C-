using BaseDomain.BaseItem;
using EccomersAPI.CommonDomain.Users;
using EccomersAPI.Db.DatabaseDomain;
using EccomersAPI.Repositories.Cart;
using EccomersAPI.Repositories.UserRepository;
using EcommersAPI.Domain.Cart;
using EcommersAPI.Domain.UserDomain;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace Ecommers_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShoppingCartController: ControllerBase
    {
        IMongoCollection<ShoppingCart> ShoppingCartCollection;
        CartRepository repository = null;
        public ShoppingCartController(Database db, CartRepository rez)
        {
            this.repository = rez;
            this.ShoppingCartCollection = db.GetCollection<ShoppingCart>("ShoppingCarts");
        }
        [HttpPost("CreateShoppingCart")]
        public async Task<string> CreateShoppingCart(BaseShoppingCart request)
        {
            ShoppingCart shop = new ShoppingCart(request,0);
            return await this.repository.Create(shop);
        }
        [HttpDelete("DeleteShoppingCart")]
        public async Task<bool> DeleteShoppingCart(string Id)
        {
            return await this.repository.Delete(Id);
        }
        [HttpPut("UpdateShoppingCart")]
        public async Task<bool> UpdateShoppingCart(string Id, BaseShoppingCart shoppingCart)
        {
            ShoppingCart Shop = new ShoppingCart();
            Shop.Id = Id;
            return await this.repository.Update(Shop);
        }
        [HttpGet("GetShoppingCartById")]
        public async Task<ShoppingCart> GetShoppingCartbyId(string Id)
        {
            return await this.repository.GetById(Id);
        }
        [HttpGet("GetAllShoppingCarts")]
        public async Task<List<ShoppingCart>> GetAllShoppingCarts()
        {
            return await this.repository.GetAll();
        }
    }
}
