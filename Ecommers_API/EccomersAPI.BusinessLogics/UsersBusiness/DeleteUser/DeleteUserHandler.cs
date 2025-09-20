using EccomersAPI.DataAbstraction.Database;
using EccomersAPI.Repositories.UserRepository;
using EcomersAPI.DataAbstraction;
using EcommersAPI.Domain.UserDomain;
using MediatR;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EccomersAPI.BusinessLogics.Users.Delete
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserRequest,DeleteUserResponse>
    {
        IMongoCollection<User> usersCollection;
        IUserRepository repository = null;
        public DeleteUserHandler(IDatabase db, IUserRepository rez) 
        {
            this.repository = rez;
            this.usersCollection = db.GetCollection<User>();
        }
        public async Task<DeleteUserResponse> Handle(DeleteUserRequest request, CancellationToken cancellationToken)
        {
            DeleteUserResponse response =new DeleteUserResponse();
            response.result=await this.repository.Delete(request.Id);
            return response;
        }
    }
}
