using EcomersAPI.DataAbstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommersAPI.Domain.UserDomain
{
    public interface IUserRepository: IRepository<User>
    {
        public Task<User> GetEmail(string email);
    }
}
