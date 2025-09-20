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

namespace EccomersAPI.BusinessLogics.Users.GetById
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdRequest, GetUserByIdResponse>
    {
        IMongoCollection<User> usersCollection;
        IUserRepository repository = null;
        public GetUserByIdHandler(IDatabase db, IUserRepository rez)
        {
            this.repository = rez;
            this.usersCollection = db.GetCollection<User>();
        }
        public async Task<GetUserByIdResponse> Handle(GetUserByIdRequest request, CancellationToken cancellationToken)
        {
            User u = await this.repository.GetById(request.Id);
            GetUserByIdResponse response=new GetUserByIdResponse();
            response.user = u;
            return response;
        }
    }
}
