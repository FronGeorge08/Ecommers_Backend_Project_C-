using EccomersAPI.BusinessLogics.Products.Update;
using EccomersAPI.DataAbstraction.Extensions;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EccomersAPI.BusinessLogics.ProductsBusiness.UpdateProduct
{
    public class UpdateProductValidator:AbstractValidator<UpdateProductRequest>
    {
        public UpdateProductValidator() 
        {
            this.RuleFor(request=>request.Name).NotEmpty().WithMessage("Please insert a name").MaximumLength(50);
            this.RuleFor(request => request.Description).MaximumLength(200).NotEmpty().WithMessage("Please write a description");
            this.RuleFor(request=>request.Id).Must((Id)=>Id.IsValidId()).WithMessage("The Id is wrong");
        }
    }
}
