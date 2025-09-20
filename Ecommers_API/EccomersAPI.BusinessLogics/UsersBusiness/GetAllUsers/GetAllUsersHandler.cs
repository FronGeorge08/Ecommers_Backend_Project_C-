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

namespace EccomersAPI.BusinessLogics.Users.GetAllUsers
{
    public class GetAllUsersHandler : IRequestHandler<GetAllUsersRequest,GetAllUsersResponse>
    {
        IMongoCollection<User> usersCollection;
        IUserRepository repository = null;
        public GetAllUsersHandler(IDatabase db, IUserRepository rez)
        {
            this.repository = rez;
            this.usersCollection = db.GetCollection<User>();
        }
        public async Task<GetAllUsersResponse> Handle(GetAllUsersRequest request, CancellationToken cancellationToken)
        {
            GetAllUsersResponse response = new GetAllUsersResponse();
            response.users=await this.repository.GetAll();
            return response;
        }
    }
}
