using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseDomain.BaseUser
{
    public class BaseUser
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public BaseUser(string name,string email,string password,string userName)
        {
            this.UserName = userName;
            this.Email = email;
            this.Password = password;
            this.Name = name;
        }
        public BaseUser()
        {

        }
    }
}
