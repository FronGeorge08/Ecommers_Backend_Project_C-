using EccomersAPI.DataAbstraction;
using EccomersAPI.DataAbstraction.Database;
using EccomersAPI.DataAbstraction.Security;
using EcommersAPI.Domain.UserDomain;
using MediatR;
using MongoDB.Driver;
namespace EccomersAPI.BusinessLogics.UsersBusiness.LoginUser
{
    public class LoginUserHandler : IRequestHandler<LoginUserRequest, LoginUserResponse>
    {
        IMongoCollection<User> mongoCollection;
        IUserRepository userRepository;
        IHashingService hashingService;
        IAuthService authService;
        public LoginUserHandler(IDatabase db, IUserRepository rep, IHashingService hash,IAuthService service) 
        {
            this.mongoCollection = db.GetCollection<User>();
            this.userRepository = rep;
            this.hashingService = hash;
            this.authService= service;
        }
        public async Task<LoginUserResponse> Handle(LoginUserRequest request, CancellationToken cancellationToken)
        {
            LoginUserResponse response=new LoginUserResponse(); 
            User user = await this.userRepository.GetEmail(request.Email);
            if (user == null)
                response.Message = "Email is inccorect, enter a valid email.";
            else if (this.hashingService.VerifyPassword(request.Password, user.Password, user.Salt))
            {
                response.Message = "Login succesfully";
                response.AccesToken= authService.GenerateAccessToken(user.Id, user.Email, IRole.User);
                response.RefreshToken= authService.GenerateRefreshToken(user.Id); 
            }
            else
                response.Message = "Password isn't correct.";
            return response;
        }
    }
}
