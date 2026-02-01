using AutoMapper;
using EccomersAPI.BusinessLogics.Products.Register;
using EccomersAPI.BusinessLogics.ShoppingCartBusiness.RegisterShoppingCart;
using EccomersAPI.CommonDomain.Products;
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
            this.CreateMap<CreateProductDTO,Product>().ReverseMap();
            this.CreateMap<GetProductByIdDTO, Product>().ReverseMap();
            this.CreateMap<GetUserByIdDTO,User>().ReverseMap();
            this.CreateMap<CreateUserDTO, User>().ReverseMap();
            this.CreateMap<RegisterProductRequest, Product>().ReverseMap();
            this.CreateMap<RegisterShoppingCartRequest, ShoppingCart>().ReverseMap();
        }
    }
}
