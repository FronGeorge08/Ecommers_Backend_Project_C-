using BaseDomain.BaseProduct;
using EcommersAPI.Domain.ProductDomain;
using MediatR;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EccomersAPI.BusinessLogics.Products.Update
{
    public class UpdateProductRequest:BaseProduct,IRequest<UpdateProductResponse>
    {
        public string Id { get; set; }
        public UpdateProductRequest(string name, string description, double price, int quantity, string brand) : base(name, description, price, quantity, brand)
        {
            this.Name = name;
            this.Description = description;
            this.Price = price;
            this.Quantity = quantity;
            this.Brand = brand;
        }
        public UpdateProductRequest(UpdateProductRequest productDTO) : base(productDTO.Name, productDTO.Description, productDTO.Price, productDTO.Quantity, productDTO.Brand)
        {
            this.Name = productDTO.Name;
            this.Description = productDTO.Description;
            this.Price = productDTO.Price;
            this.Quantity = productDTO.Quantity;
            this.Brand = productDTO.Brand;
        }
        public UpdateProductRequest()
        {

        }
    }
}
