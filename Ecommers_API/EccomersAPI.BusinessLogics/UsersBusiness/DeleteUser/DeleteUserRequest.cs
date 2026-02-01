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
    public class DeleteUserRequest:IRequest<DeleteUserResponse>
    {
        public string Id { get; set; }
        public DeleteUserRequest()
        {

        }
        
    }
}
