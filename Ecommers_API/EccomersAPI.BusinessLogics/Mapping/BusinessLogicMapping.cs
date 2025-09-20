using AutoMapper;
using EccomersAPI.BusinessLogics.Products.Register;
using EccomersAPI.BusinessLogics.ShoppingCartBusiness.RegisterShoppingCart;
using EccomersAPI.CommonDomain.Users;
using EcommersAPI.Domain.Cart;
using EcommersAPI.Domain.ProductDomain;
using EcommersAPI.Domain.UserDomain;

namespace EccomersAPI.BusinessLogics.Mapping
{
    public class BusinessLogicMapping :Profile
    {
        public BusinessLogicMapping() 
        {
            this.CreateMap<RegisterUserRequest, User>().ReverseMap();
            this.CreateMap<RegisterProductRequest, Product>().ReverseMap();
            this.CreateMap<RegisterShoppingCartRequest, ShoppingCart>().ReverseMap();
        }
    }
}
