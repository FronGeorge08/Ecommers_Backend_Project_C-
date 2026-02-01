using AutoMapper;
using EccomersAPI.CommonDomain.Users;
using EccomersAPI.DataAbstraction;
using EccomersAPI.DataAbstraction.Security;
using EcommersAPI.Domain.UserDomain;
using MediatR.Pipeline;
namespace EccomersAPI.BusinessLogics.UsersBusiness.RegisterUser
{
    public class RegisterUserHandlerPreprocessor : IRequestPreProcessor<RegisterUserRequest>
    {
        IHashingService _hashingService;
        IMapper _mapper;
        public IContextProvider ContextProvider;
        public RegisterUserHandlerPreprocessor(IHashingService hash,IMapper map,IContextProvider context) 
        {
            this._hashingService = hash;
            this._mapper = map;
            this.ContextProvider = context;
        }
        public async Task Process(RegisterUserRequest request, CancellationToken cancellationToken)
        {
            User user = this._mapper.Map<User>(request);
            string salt = _hashingService.GenerateSalt();
            string hashedPassword = _hashingService.HashPassword(user.Password, salt);
            user.Password = hashedPassword;
            user.Salt = salt;
            ContextProvider.Set("User", user);  
            await Task.CompletedTask;
        }
    }
}
