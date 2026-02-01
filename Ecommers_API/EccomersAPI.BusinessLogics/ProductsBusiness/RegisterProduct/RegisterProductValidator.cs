using EccomersAPI.BusinessLogics.Products.Register;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EccomersAPI.DataAbstraction.Extensions;
namespace EccomersAPI.BusinessLogics.ProductsBusiness.RegisterProduct
{
    public class RegisterProductValidator:AbstractValidator<RegisterProductRequest>
    {
        public RegisterProductValidator()
        {
            this.RuleFor(request => request.Name).NotEmpty().WithMessage("Please insert a name").MaximumLength(50);
            this.RuleFor(request => request.Description).MaximumLength(200).NotEmpty().WithMessage("Please write a description");
            this.RuleFor(request => request.Id).Must((Id) => Id.IsValidId()).WithMessage("The Id is wrong");
        }
    }
}
