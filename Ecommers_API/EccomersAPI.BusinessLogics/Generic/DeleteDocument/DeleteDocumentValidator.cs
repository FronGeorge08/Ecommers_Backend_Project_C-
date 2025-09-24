using EccomersAPI.DataAbstraction;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EccomersAPI.DataAbstraction.Extensions;
namespace EccomersAPI.BusinessLogics.Generic.DeleteDocument
{
    public class DeleteDocumentValidator<TEntityToDelete>:AbstractValidator<DeleteDocumentRequest<TEntityToDelete>>
    where TEntityToDelete : IContainsId
    {
        public DeleteDocumentValidator()
        {
            this.RuleFor(request => request.Id).Must((Id) => Id.IsValidId()).WithMessage("Invalid Id");
        }
    }
}
