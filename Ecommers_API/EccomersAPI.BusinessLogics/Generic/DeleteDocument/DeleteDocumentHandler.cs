using AutoMapper;
using EccomersAPI.DataAbstraction;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EccomersAPI.BusinessLogics.Generic.DeleteDocument
{
    public class DeleteDocumentHandler<TEntityToDelete> : IRequestHandler<DeleteDocumentRequest<TEntityToDelete>, DeleteDocumentResponse>
    where TEntityToDelete : IContainsId
    {
        IGenericCrudRepository<TEntityToDelete> _repository;
        public DeleteDocumentHandler(IGenericCrudRepository<TEntityToDelete> rep,IMapper map)
        {
            this._repository = rep;
        }
        public async Task<DeleteDocumentResponse> Handle(DeleteDocumentRequest<TEntityToDelete> request, CancellationToken cancellationToken)
        {
            return new DeleteDocumentResponse { Response = await this._repository.Delete(request.Id) };
        }
    }
}
