using BaseDomain.BaseUser;
using EccomersAPI.BusinessLogics.Users.Update;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace EccomersAPI.CommonDomain.Users
{
    public class UpdateUserRequest : BaseUser,IRequest<UpdateUserResponse>
    {
        public string Id { get; set; }
        public UpdateUserRequest()
        {

        }
        public UpdateUserRequest(string id,string name, string email, string password, string username)
        {
            this.Id = id;
            this.UserName = username;
            this.Email = email;
            this.Password = password;
            this.Name = name;
        }
        public UpdateUserRequest(UpdateUserRequest user) : base(user.Name, user.Email, user.Password, user.UserName)
        {
            this.Id= user.Id;
            this.UserName = user.UserName;
            this.Email = user.Email;
            this.Password = user.Password;
            this.Name = user.Name;
        }
    }
}
