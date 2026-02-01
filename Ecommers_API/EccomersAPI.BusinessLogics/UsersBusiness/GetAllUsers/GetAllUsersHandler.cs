using EccomersAPI.DataAbstraction.Database;
using EcommersAPI.Domain.UserDomain;
using MediatR;
using MongoDB.Driver;

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
