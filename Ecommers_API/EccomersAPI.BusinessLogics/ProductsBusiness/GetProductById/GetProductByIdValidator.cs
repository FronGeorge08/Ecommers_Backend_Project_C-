using EccomersAPI.BusinessLogics.Products.GetById;
using EccomersAPI.DataAbstraction.Extensions;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EccomersAPI.BusinessLogics.ProductsBusiness.GetProductById
{
    public class GetProductByIdValidator:AbstractValidator<GetProductByIdRequest>
    {
        public GetProductByIdValidator()
        {
            this.RuleFor(request=>request.Id).Must((Id)=>Id.IsValidId()).WithMessage("Id doesn't exist");
        }
    }
}
