using EccomersAPI.BusinessLogics.Products.GetAllProducts;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EccomersAPI.BusinessLogics.ProductsBusiness.GetAllProducts
{
    public class GetAllProductsValidator:AbstractValidator<GetAllProductsRequest>
    {
        public GetAllProductsValidator() { }
    }
}
