using EccomersAPI.DataAbstraction;
using MediatR;
using System.Text.Json.Serialization;

namespace EccomersAPI.BusinessLogics.Generic.CreateDocument
{
    public class CreateDocumentRequest<TRequestDataDTO, TEntityToSave> : IRequest<CreateDocumentResponse>
    where TRequestDataDTO : class
    where TEntityToSave:class,IContainsId
    {
        public TRequestDataDTO Request { get; set; }
        [JsonIgnore]
        public Action<TEntityToSave> ? OnBeforeInsert { get; set; }
    }
}
