using EccomersAPI.BusinessLogics.Generic.CreateDocument;
using EccomersAPI.BusinessLogics.Generic.DeleteDocument;
using EccomersAPI.BusinessLogics.Generic.GetDocumentById;
using EccomersAPI.BusinessLogics.Users.Delete;
using EccomersAPI.BusinessLogics.Users.GetAllUsers;
using EccomersAPI.BusinessLogics.Users.GetById;
using EccomersAPI.BusinessLogics.Users.Register;
using EccomersAPI.BusinessLogics.Users.Update;
using EccomersAPI.BusinessLogics.UsersBusiness.Factory;
using EccomersAPI.BusinessLogics.UsersBusiness.GetUserById;
using EccomersAPI.BusinessLogics.UsersBusiness.LoginUser;
using EccomersAPI.CommonDomain.Users;
using EccomersAPI.DataAbstraction.Database;
using EccomersAPI.Db.DatabaseDomain;
using EccomersAPI.Repositories.UserRepository;
using EcomersAPI.DataAbstraction;
using EcommersAPI.Domain.ProductDomain;
using EcommersAPI.Domain.UserDomain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design.Serialization;
using System.Threading;
using System.Threading.Tasks;
namespace Ecommers_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        
        IMediator mediator;
        UserModifierFactory modifierFactory;
        public UserController(IMediator med,UserModifierFactory mod)
        {
            this.mediator = med; 
            this.modifierFactory = mod;
        }
        [HttpPost("CreateUser")]
        public async Task<string> CreateUser(CreateDocumentRequest<CreateUserDTO, User> request)
        {
            var modifier = await this.modifierFactory.CreateModifier(request.Request.Password);
            request.OnBeforeInsert = modifier;
            var response=await this.mediator.Send(request);
            return response.Id;
        }
        [HttpPost ("LoginUser")]
        public async Task<string> LoginUser(LoginUserRequest request)
        {
            LoginUserResponse response = await this.mediator.Send(request);
            return response.Message;
        }
        [HttpDelete("DeleteUser")]
        public async Task<bool> DeleteUser(string Id)
        {
            DeleteDocumentRequest<User> request=new DeleteDocumentRequest<User> {Id = Id};
            DeleteDocumentResponse response = await this.mediator.Send(request);
            return response.Response;
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
            GetDocumentByIdRequest<GetUserByIdDTO, User> request = new GetDocumentByIdRequest<GetUserByIdDTO, User>(Id);
            GetDocumentByIdResponse<GetUserByIdDTO,User> response = await this.mediator.Send(request);
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
