using EccomersAPI.BusinessLogics.Users.GetById;
using FluentValidation;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EccomersAPI.DataAbstraction.Extensions;
namespace EccomersAPI.BusinessLogics.UsersBusiness.GetUserById
{
    public class GetUserByIdValidator:AbstractValidator<GetUserByIdRequest>
    {
        public GetUserByIdValidator() 
        {
            this.RuleFor(request => request.Id).Must((Id) => Id.IsValidId()).WithMessage("Invalid Id"); 
        }
        
    }
}
