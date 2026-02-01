using EccomersAPI.DataAbstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EccomersAPI.BusinessLogics.Generic.GetDocumentById
{
    public class GetDocumentByIdResponse<TResponseDataDTO, TEntityToReturn>
    where TResponseDataDTO : class
    where TEntityToReturn :IContainsId
    {
        public TResponseDataDTO entityToReturn { get; set; }
    }
}
