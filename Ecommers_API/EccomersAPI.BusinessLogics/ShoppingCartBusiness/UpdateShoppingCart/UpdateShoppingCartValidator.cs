using EccomersAPI.DataAbstraction.Extensions;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EccomersAPI.BusinessLogics.ShoppingCartBusiness.UpdateShoppingCart
{
    public class UpdateShoppingCartValidator:AbstractValidator<UpdateShoppingCartRequest>
    {
        public UpdateShoppingCartValidator()
        {
            this.RuleFor(request => request.UserId).NotEmpty().Must((Id) => Id.IsValidId()).WithMessage("Id doesn't exist");
        }
    }
}
