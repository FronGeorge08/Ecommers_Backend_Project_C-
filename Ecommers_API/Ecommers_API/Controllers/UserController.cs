using Microsoft.AspNetCore.Mvc;
using EcommersAPI.Domain.UserDomain;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Threading.Tasks;
using EcommersAPI.Domain.ProductDomain;
using System.ComponentModel.Design.Serialization;
using EccomersAPI.Db.DatabaseDomain;
using EccomersAPI.CommonDomain.Users;
using EccomersAPI.Repositories.UserRepository;
using MediatR;
using EccomersAPI.BusinessLogics.Users.Delete;
using EccomersAPI.BusinessLogics.Users.GetAllUsers;
using EccomersAPI.BusinessLogics.Users.GetById;
using EccomersAPI.BusinessLogics.Users.Update;
using EccomersAPI.BusinessLogics.Users.Register;
namespace Ecommers_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        IMongoCollection<User> usersCollection;
        UserRepository repository = null;
        IMediator mediator;
        public UserController(Database db,UserRepository rez,IMediator med)
        {
            this.repository=rez;
            this.mediator = med;
            this.usersCollection = db.GetCollection<User>("Users");
        }
        [HttpPost("CreateUser")]
        public async Task<string> CreateUser(RegisterUserRequest request)
        {
            RegisterUserResponse response=await this.mediator.Send(request);
            return response.Id;
        }
        [HttpDelete("DeleteUser")]
        public async Task<bool> DeleteUser(DeleteUserRequest request)
        {
            DeleteUserResponse response=await this.mediator.Send(request);
            return response.result;
        }
        [HttpPut("UpdateUser")]
        public async Task<bool> UpdateUser(UpdateUserRequest request)
        {
            UpdateUserResponse response = await this.mediator.Send(request);
            return response.result;
        }
        [HttpGet("GetUserById")]
        public async Task<User> GetUserbyId(GetByIdRequest request)
        {
            GetByIdResponse response= await this.mediator.Send(request);
            return response.user;
        }
        [HttpGet("GetAllUsers")]
        public async Task<List<User>> GetAllUsers(GetAllUsersRequest request)
        {
            GetAllUsersResponse response = await this.mediator.Send(request);
            return response.users;
        }
    }
}
