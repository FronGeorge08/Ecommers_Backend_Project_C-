using EccomersAPI.DataAbstraction.Extensions;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EccomersAPI.BusinessLogics.ShoppingCartBusiness.DeleteShoppingCarts
{
    public class DeleteShoppingCartsValidator:AbstractValidator<DeleteShoppingCartsRequest>
    {
        public DeleteShoppingCartsValidator()
        {
            this.RuleFor(request=>request.Id).NotEmpty().Must((Id)=>Id.IsValidId()).WithMessage("Id doesn't exist");
        }
    }
}
