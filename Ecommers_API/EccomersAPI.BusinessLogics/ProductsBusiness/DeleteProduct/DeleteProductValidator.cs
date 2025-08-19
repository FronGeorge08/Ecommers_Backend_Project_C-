using EccomersAPI.BusinessLogics.Products.Delete;
using EccomersAPI.DataAbstraction.Extensions;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EccomersAPI.BusinessLogics.ProductsBusiness.DeleteProduct
{
    public class DeleteProductValidator:AbstractValidator<DeleteProductRequest>
    {
        public DeleteProductValidator() 
        {
            this.RuleFor(request=>request.Id).NotEmpty().Must((id)=>id.IsValidId()).WithMessage("Id doesn't exist");
        }
    }
}
