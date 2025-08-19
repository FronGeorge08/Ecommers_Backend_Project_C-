using EccomersAPI.CommonDomain.Users;
using EccomersAPI.DataAbstraction.Extensions;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EccomersAPI.DataAbstraction.Extensions;
namespace EccomersAPI.BusinessLogics.UsersBusiness.UpdateUser
{
    public class UpdateUserValidator:AbstractValidator<UpdateUserRequest>
    {
        public UpdateUserValidator() 
        {
            this.RuleFor(request => request.Id).Must((Id) => Id.IsValidId()).WithMessage("Invalid Id");
            this.RuleFor(request => request.Email).NotEmpty().WithMessage("Please provide a Email")
            .Must((Email)=>Email.EmailCheck()).WithMessage("Please provide a Email");
            this.RuleFor(request => request.Password).NotEmpty().WithMessage("Password not Provided")
            .MaximumLength(50).MinimumLength(10).WithMessage("Password must be 10 characters or longer");
        }
    }
}
