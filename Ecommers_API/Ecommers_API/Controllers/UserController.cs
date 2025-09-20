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
using System.ComponentModel.DataAnnotations;
using EccomersAPI.BusinessLogics.UsersBusiness.GetUserById;
using System.Threading;
using EccomersAPI.BusinessLogics.UsersBusiness.LoginUser;
using EcomersAPI.DataAbstraction;
using EccomersAPI.DataAbstraction.Database;
namespace Ecommers_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        
        IMediator mediator;
        public UserController(IMediator med)
        {
            this.mediator = med; 
        }
        [HttpPost("CreateUser")]
        public async Task<string> CreateUser(RegisterUserRequest request)
        {
            RegisterUserResponse response = await this.mediator.Send(request);
            return response.Id;
        }
        [HttpPost ("LoginUser")]
        public async Task<string> LoginUser(LoginUserRequest request)
        {
            LoginUserResponse response = await this.mediator.Send(request);
            return response.Message;
        }
        [HttpDelete("DeleteUser")]
        public async Task<bool> DeleteUser(DeleteUserRequest request)
        {
            DeleteUserResponse response = await this.mediator.Send(request);
            return response.result;
        }
        [HttpPut("UpdateUser")]
        public async Task<bool> UpdateUser(UpdateUserRequest request)
        {
            UpdateUserResponse response = await this.mediator.Send(request);
            return response.result;
        }
        [HttpGet("GetUserById/{Id}")]
        public async Task<IActionResult> GetUserbyId(string Id)
        {
            GetUserByIdRequest request = new GetUserByIdRequest();
            request.Id = Id;
            var validator = new GetUserByIdValidator();
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
            GetUserByIdResponse response = await this.mediator.Send(request);
            return this.Ok(response);
        }
        [HttpGet("GetAllUsers")]
        public async Task<List<User>> GetAllUsers()
        {
            GetAllUsersRequest request = new GetAllUsersRequest();
            GetAllUsersResponse response = await this.mediator.Send(request);
            return response.users;

        }
    }
}
