using EccomersAPI.Repositories.UserRepository;
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
    public class GetByIdHandler : IRequestHandler<GetByIdRequest, GetByIdResponse>
    {
        IMongoCollection<User> usersCollection;
        UserRepository repository = null;
        public GetByIdHandler(EccomersAPI.Db.DatabaseDomain.Database db, UserRepository rez)
        {
            this.repository = rez;
            this.usersCollection = db.GetCollection<User>("Users");
        }
        public async Task<GetByIdResponse> Handle(GetByIdRequest request, CancellationToken cancellationToken)
        {
            User u = await this.repository.GetById(request.Id);
            GetByIdResponse response=new GetByIdResponse();
            response.user = u;
            return response;
        }
    }
}
