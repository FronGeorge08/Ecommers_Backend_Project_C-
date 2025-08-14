using BaseDomain.BaseUser;
using EccomersAPI.CommonDomain.Users;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EccomersAPI.BusinessLogics.Users.GetById
{
    public class GetByIdRequest:BaseUser,IRequest<GetByIdResponse>
    {
        public string Id { get; set; }
        public GetByIdRequest(string name, string email, string password, string userName) : base(name, email, password, userName)
        {
            this.Name = name;
            this.Email = email;
            this.Password = password;
            this.UserName = userName;
        }
        public GetByIdRequest(GetByIdRequest userDTO) : base(userDTO.Name, userDTO.Email, userDTO.Password, userDTO.UserName)
        {
            this.Name = userDTO.Name;
            this.Email = userDTO.Email;
            this.Password = userDTO.Password;
            this.UserName = userDTO.UserName;
        }
        public GetByIdRequest()
        {

        }
    }
}
