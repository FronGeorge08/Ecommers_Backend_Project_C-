using BaseDomain.BaseUser;
using EccomersAPI.CommonDomain.Users;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EccomersAPI.BusinessLogics.Users.Delete
{
    public class DeleteUserRequest:BaseUser,IRequest<DeleteUserResponse>
    {
        public string Id { get; set; }
        public DeleteUserRequest()
        {

        }
        public DeleteUserRequest(string id, string name, string email, string password, string username)
        {
            this.Id = id;
            this.UserName = username;
            this.Email = email;
            this.Password = password;
            this.Name = name;
        }
        public DeleteUserRequest(DeleteUserRequest user) : base(user.Name, user.Email, user.Password, user.UserName)
        {
            this.Id = user.Id;
            this.UserName = user.UserName;
            this.Email = user.Email;
            this.Password = user.Password;
            this.Name = user.Name;
        }
    }
}
