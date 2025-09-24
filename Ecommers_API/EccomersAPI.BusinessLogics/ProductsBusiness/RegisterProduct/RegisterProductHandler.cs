using AutoMapper;
using EcommersAPI.Domain.ProductDomain;
using MediatR;

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
