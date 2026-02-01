using EccomersAPI.DataAbstraction.Extensions;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EccomersAPI.BusinessLogics.ShoppingCartBusiness.GetShoppingCartById
{
    public class GetShoppingCartByIdValidator:AbstractValidator<GetShoppingCartByIdRequest>
    {
        public GetShoppingCartByIdValidator()
        {
            RuleFor(request=>request.Id).Must((Id)=>Id.IsValidId()).WithMessage("Id doesn't exist");
        }
    }
}
