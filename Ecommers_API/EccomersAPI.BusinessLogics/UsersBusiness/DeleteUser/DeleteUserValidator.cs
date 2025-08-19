using EccomersAPI.BusinessLogics.Users.Delete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EccomersAPI.DataAbstraction.Extensions;
namespace EccomersAPI.BusinessLogics.UsersBusiness.DeleteUser
{
    public class DeleteUserValidator:AbstractValidator<DeleteUserRequest>
    {
        public DeleteUserValidator() 
        {
            this.RuleFor(request => request.Id).Must((Id) => Id.IsValidId()).WithMessage("Invalid Id");
        }    
    }
}
