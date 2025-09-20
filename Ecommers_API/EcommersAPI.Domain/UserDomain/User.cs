using Amazon.Runtime.Internal.Util;
using BaseDomain.BaseUser;
using EccomersAPI.DataAbstraction;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EcommersAPI.Domain.UserDomain
{
    public class User: BaseUser,IContainsId
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = null;
        [JsonIgnore]
        public string Salt { get; set; }
        public User(string name, string email, string password,string userName):base(name,email,password,userName)
        {
            this.Name=name;
            this.Email=email;
            this.Password=password;
            this.UserName=userName;
        }

        public User(User u)
        {
            this.Id=u.Id;
            this.Salt=u.Salt;
            this.UserName=u.UserName;
            this.Email=u.Email;
            this.Password=u.Password;
            this.Name =u.Name;
        }
           
        public User()
        {

        }
    }
}
