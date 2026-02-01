using AutoMapper;
using EcommersAPI.Domain.Cart;
using MediatR;

namespace EccomersAPI.BusinessLogics.ShoppingCartBusiness.RegisterShoppingCart
{
    public class RegisterShoppingCartHandler : IRequestHandler<RegisterShoppingCartRequest, RegisterShoppingCartResponse>
    {
        ICartRepository repository = null;
        IMapper map { get; set; }
        public RegisterShoppingCartHandler( ICartRepository rez,IMapper mapper)
        {
            this.repository = rez;
            this.map=mapper;
        }
        public async Task<RegisterShoppingCartResponse> Handle(RegisterShoppingCartRequest request, CancellationToken cancellationToken)
        {
            ShoppingCart shop = this.map.Map<ShoppingCart>(request);
            RegisterShoppingCartResponse response=new RegisterShoppingCartResponse();
            await this.repository.Create(shop);
            response.Id = shop.Id;
            return response;
        }
    }
}
