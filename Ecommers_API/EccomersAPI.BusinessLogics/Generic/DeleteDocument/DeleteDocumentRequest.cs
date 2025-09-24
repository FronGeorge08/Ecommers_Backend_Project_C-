using Amazon.Runtime.Internal;
using EccomersAPI.DataAbstraction;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EccomersAPI.BusinessLogics.Generic.DeleteDocument
{
    public class DeleteDocumentRequest<TEntityToDelete>:IRequest<DeleteDocumentResponse>
    where TEntityToDelete : IContainsId
    {
        public string Id { get; set; }
    }
}
