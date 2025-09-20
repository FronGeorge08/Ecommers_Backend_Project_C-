using MongoDB.Bson.Serialization.IdGenerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EccomersAPI.BusinessLogics.UsersBusiness.LoginUser
{
    public class LoginUserResponse
    {
        public string Message {  get; set; }
        public string AccesToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
