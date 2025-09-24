using EccomersAPI.DataAbstraction;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EccomersAPI.DataAbstraction.Extensions;
namespace EccomersAPI.BusinessLogics.Generic.GetDocumentById
{
    public class GetDocumentByIdValidator<TResponseDataDTO, TEntityToReturn> : AbstractValidator<GetDocumentByIdRequest<TResponseDataDTO, TEntityToReturn>>
    where TResponseDataDTO : class
    where TEntityToReturn : IContainsId
    {
        public GetDocumentByIdValidator() 
        {
            this.RuleFor(request => request.Id).Must((Id) => Id.IsValidId()).WithMessage("Invalid Id");
        }
    }
}
