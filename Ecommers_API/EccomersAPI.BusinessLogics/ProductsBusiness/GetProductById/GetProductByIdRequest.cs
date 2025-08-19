
using BaseDomain.BaseItem;
using BaseDomain.BaseProduct;
using EccomersAPI.BusinessLogics.Products.Delete;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EccomersAPI.BusinessLogics.Products.GetById
{
    public class GetProductByIdRequest:BaseProduct,IRequest<GetProductByIdResponse>
    {
        public string Id { get; set; }
    }
}
