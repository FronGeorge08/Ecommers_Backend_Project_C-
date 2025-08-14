using Amazon.Runtime.Internal;
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

namespace EccomersAPI.BusinessLogics.Users.Update
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserRequest,UpdateUserResponse>
    {
        IMongoCollection<User> usersCollection;
        UserRepository repository = null;
        public UpdateUserHandler(EccomersAPI.Db.DatabaseDomain.Database db, UserRepository rez)
        {
            this.repository = rez;
            this.usersCollection = db.GetCollection<User>("Users");
        }
        public async Task<UpdateUserResponse> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
        {
            User u = new User();
            u.Id = request.Id;
            u.UserName=request.UserName;
            u.Password=request.Password;
            u.Email=request.Email;
            u.Name=request.Name;
            UpdateUserResponse response = new UpdateUserResponse();
            response.result= await this.repository.Update(u);
            return response;
        }
    }
}
