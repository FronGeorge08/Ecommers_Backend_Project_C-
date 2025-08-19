using EccomersAPI.CommonDomain.Users;
using EccomersAPI.Repositories.UserRepository;
using EcommersAPI.Domain.UserDomain;
using MediatR;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EccomersAPI.BusinessLogics.Users.Register
{
    public class RegisterUserHandler : IRequestHandler<RegisterUserRequest,RegisterUserResponse>
    {
        IMongoCollection<User> usersCollection;
        UserRepository repository = null;
        public RegisterUserHandler(EccomersAPI.Db.DatabaseDomain.Database db, UserRepository rez)
        {
            this.repository = rez;
            this.usersCollection = db.GetCollection<User>("Users");
        }
        
        public async Task<RegisterUserResponse> Handle(RegisterUserRequest request, CancellationToken cancellationToken)
        {
            User user=new User();
            user.Name = request.Name;
            user.Email = request.Email;
            user.Password = request.Password;
            user.UserName = request.UserName;
            await this.repository.Create(user);
            RegisterUserResponse response= new RegisterUserResponse();
            response.Id = user.Id;
            return response;
        }
    }
}
