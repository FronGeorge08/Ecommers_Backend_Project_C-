using EccomersAPI.DataAbstraction.Extensions;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EccomersAPI.BusinessLogics.ShoppingCartBusiness.RegisterShoppingCart
{
    public class RegisterShoppingCartValidator:AbstractValidator<RegisterShoppingCartRequest>
    {
        public RegisterShoppingCartValidator() 
        {
            RuleFor(request=>request.UserId).Must((Id)=>Id.IsValidId()).WithMessage("Id doesn't exist");
        }
    }
}
