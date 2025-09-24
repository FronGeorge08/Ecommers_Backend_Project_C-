using AutoMapper;
using EccomersAPI.DataAbstraction;
using MediatR;

namespace EccomersAPI.BusinessLogics.Generic.GetDocumentById
{
    public class GetDocumentByIdHandler<TDTOResponse, TDatabaseEntity> : IRequestHandler<GetDocumentByIdRequest<TDTOResponse, TDatabaseEntity>, GetDocumentByIdResponse<TDTOResponse, TDatabaseEntity>>
    where TDTOResponse : class
    where TDatabaseEntity : IContainsId
    {
        private readonly IGenericCrudRepository<TDatabaseEntity> repository;
        IMapper mapper;
        public GetDocumentByIdHandler(IGenericCrudRepository<TDatabaseEntity> rep, IMapper map)
        {
            this.repository = rep;
            this.mapper = map;
        }
        public async Task<GetDocumentByIdResponse<TDTOResponse, TDatabaseEntity>> Handle(GetDocumentByIdRequest<TDTOResponse, TDatabaseEntity> request, CancellationToken cancellationToken)
        {
            TDatabaseEntity EntityToReturn=await this.repository.GetById(request.Id);
            var entity = this.mapper.Map<TDTOResponse>(EntityToReturn);
            return new GetDocumentByIdResponse<TDTOResponse, TDatabaseEntity>
            {
                entityToReturn = entity
            };
        }
    }
}
