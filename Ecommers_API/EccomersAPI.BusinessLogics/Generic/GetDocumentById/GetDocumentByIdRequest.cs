using EccomersAPI.DataAbstraction;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EccomersAPI.BusinessLogics.Generic.GetDocumentById
{
    public class GetDocumentByIdRequest<TResponseDataDTO, TEntityToReturn> :IRequest<GetDocumentByIdResponse<TResponseDataDTO,TEntityToReturn>>
    where TResponseDataDTO : class
    where TEntityToReturn : IContainsId
    {
        public string Id { get; set; }
        public GetDocumentByIdRequest (string id)
        {
            this.Id=id;
        }
    }
}
