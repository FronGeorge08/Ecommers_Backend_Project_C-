using EcommersAPI.Domain.UserDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EccomersAPI.BusinessLogics.Users.GetAllUsers
{
    public class GetAllUsersResponse
    {
        public List<User> users {  get; set; }
    }
}
