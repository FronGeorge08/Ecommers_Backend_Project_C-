using EccomersAPI.DataAbstraction.Security;
using EcommersAPI.Domain.UserDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EccomersAPI.BusinessLogics.UsersBusiness.Factory
{
    public class UserModifierFactory
    {
        IHashingService _hashingService;
        public UserModifierFactory(IHashingService service) 
        {
            this._hashingService = service;
        }
        public async Task<Action<User>> CreateModifier(string password)
        {
            string salt = _hashingService.GenerateSalt();
            return user =>
            {
                user.Password = _hashingService.HashPassword(password, salt);
                user.Salt = salt;
            };
        }
    }
}
