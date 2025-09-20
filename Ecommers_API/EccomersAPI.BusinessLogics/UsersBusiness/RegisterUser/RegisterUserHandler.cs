using AutoMapper;
using EccomersAPI.CommonDomain.Users;
using EccomersAPI.DataAbstraction.Database;
using EccomersAPI.DataAbstraction.Security;
using EcommersAPI.Domain.UserDomain;
using MediatR;
using EccomersAPI.BusinessLogics.UsersBusiness.RegisterUser;
using EccomersAPI.DataAbstraction;
namespace EccomersAPI.BusinessLogics.Users.Register
{
    public class RegisterUserHandler : IRequestHandler<RegisterUserRequest,RegisterUserResponse>
    {
        IUserRepository repository;
        IMapper map;
        public IContextProvider contextProvider;
        IEmailService emailService;
        public RegisterUserHandler(IUserRepository rez,IMapper mapper,IContextProvider context,IEmailService service)
        {
            this.repository = rez;
            this.map = mapper;
            this.contextProvider = context;
            this.emailService = service;
        }
        
        public async Task<RegisterUserResponse> Handle(RegisterUserRequest request, CancellationToken cancellationToken)
        {
            User u =new User((User)contextProvider.Get("User"));
            emailService.SendVerificationCode(u.Email, "1234");
            await this.repository.Create(u);
            return new RegisterUserResponse(u.Id); 
        }
    }
}
