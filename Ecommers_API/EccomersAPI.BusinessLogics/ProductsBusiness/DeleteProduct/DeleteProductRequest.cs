using BaseDomain.BaseProduct;
using EccomersAPI.BusinessLogics.Users.Delete;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EccomersAPI.BusinessLogics.Products.Delete
{
    public class DeleteProductRequest:BaseProduct,IRequest<DeleteProductResponse>
    {
        public string Id { get; set; }
        public DeleteProductRequest()
        {

        }
    }
}
