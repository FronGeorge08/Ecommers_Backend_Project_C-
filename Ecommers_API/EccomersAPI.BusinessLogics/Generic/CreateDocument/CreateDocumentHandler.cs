using AutoMapper;
using EccomersAPI.DataAbstraction;
using MediatR;
using System.Net;

namespace EccomersAPI.BusinessLogics.Generic.CreateDocument
{
    public class CreateDocumentHandler<TRequestDataDTO, TEntityToSave> : IRequestHandler<CreateDocumentRequest<TRequestDataDTO, TEntityToSave>, CreateDocumentResponse>
    where TRequestDataDTO : class
    where TEntityToSave : class,IContainsId
    {
        IGenericCrudRepository<TEntityToSave> repository;
        IMapper mapper;
        public CreateDocumentHandler(IGenericCrudRepository<TEntityToSave> rep,IMapper mapper) 
        {
            this.repository = rep;
            this.mapper = mapper;
        }
        public async Task<CreateDocumentResponse> Handle(CreateDocumentRequest<TRequestDataDTO, TEntityToSave> request, CancellationToken cancellationToken)
        {
            TEntityToSave entity= this.mapper.Map<TEntityToSave>(request.Request);
            if (request.OnBeforeInsert!=null) 
                request.OnBeforeInsert.Invoke(entity);
            string id=await this.repository.Create(entity);
            return new CreateDocumentResponse{Id=id,StatusCode=HttpStatusCode.Created,Message="Succes"};
        }
    }
}
