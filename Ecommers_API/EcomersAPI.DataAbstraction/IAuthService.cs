using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EccomersAPI.DataAbstraction
{
    public interface IAuthService 
    {
        public string GenerateAccessToken(string id, string email, IRole role);
        public string GenerateRefreshToken(string id);
    }
}
