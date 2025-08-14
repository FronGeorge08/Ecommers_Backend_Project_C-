using BaseDomain.BaseUser;
using EccomersAPI.CommonDomain.Users;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommersAPI.Domain.UserDomain
{
    public class User: BaseUser
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = null;
        public User(string name, string email, string password,string userName):base(name,email,password,userName)
        {
            this.Name=name;
            this.Email=email;
            this.Password=password;
            this.UserName=userName;
        }

        public User()
        {

        }
    }
}
