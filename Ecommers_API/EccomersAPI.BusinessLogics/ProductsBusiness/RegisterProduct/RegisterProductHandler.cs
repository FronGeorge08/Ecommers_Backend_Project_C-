using AutoMapper;
using EccomersAPI.DataAbstraction.Database;
using EccomersAPI.Repositories.ProductRepository;
using EcomersAPI.DataAbstraction;
using EcommersAPI.Domain.ProductDomain;
using MediatR;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EccomersAPI.BusinessLogics.Products.Register
{
    public class RegisterProductHandler : IRequestHandler<RegisterProductRequest, RegisterProductResponse>
    {
        IProductRepository result = null;
        IMapper map {  get; set; }
        public RegisterProductHandler(IProductRepository rez,IMapper mapper)
        {
            this.result = rez;
            this.map = mapper;
        }
        public async Task<RegisterProductResponse> Handle(RegisterProductRequest request, CancellationToken cancellationToken)
        {
            Product product = this.map.Map<Product>(request);
            await this.result.Create(product);
            RegisterProductResponse response=new RegisterProductResponse();
            response.ProductId=product.Id;
            return response;
        }
    }
}
