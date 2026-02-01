using EccomersAPI.DataAbstraction;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EccomersAPI.BusinessLogics.Generic.CreateDocument
{
    public class CreateDocumentValidator<TRequestDataDTO, TEntityToSave> : AbstractValidator <CreateDocumentRequest<TRequestDataDTO, TEntityToSave>>
        where TRequestDataDTO : class
        where TEntityToSave :class,IContainsId
    {
        public CreateDocumentValidator() 
        {
            this.RuleFor(request => request.Request).NotNull().WithMessage("The entity is null");
        }    
    }
}
