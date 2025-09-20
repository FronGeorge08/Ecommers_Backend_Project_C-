using EccomersAPI.DataAbstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EccomersAPI.Services
{
    public class AuthSettings:IAuthSettings
    {
        public string SecretKey { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int AccesTokenLifeTime { get; set; }
        public int RefreshTokenLifeTime { get; set; }
    }
}
