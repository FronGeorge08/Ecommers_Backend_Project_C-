using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EccomersAPI.DataAbstraction.Extensions;
namespace EccomersAPI.BusinessLogics.UsersBusiness.LoginUser
{
    public class LoginUserValidator:AbstractValidator<LoginUserRequest>
    {
        public LoginUserValidator() 
        {
            this.RuleFor(request => request.Email).NotEmpty().WithMessage("Email not Provided")
           .Must((Email) => Email.EmailCheck()).WithMessage("Please provide a email");
            this.RuleFor(request => request.Password).NotEmpty().WithMessage("Password not Provided")
            .MaximumLength(50).MinimumLength(10).WithMessage("Password must be 10 characters or longer");
        }
    }
}
