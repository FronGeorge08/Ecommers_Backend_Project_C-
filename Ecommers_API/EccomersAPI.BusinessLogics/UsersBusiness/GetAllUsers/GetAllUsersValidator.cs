using EccomersAPI.BusinessLogics.Users.GetAllUsers;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EccomersAPI.BusinessLogics.UsersBusiness.GetAllUsers
{
    public class GetAllUsersValidator:AbstractValidator<GetAllUsersRequest>
    {
        public GetAllUsersValidator() 
        {
           
        }   
    }
}
