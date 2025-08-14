using BaseDomain.BaseProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EccomersAPI.CommonDomain.Products
{
    public class UpdateProductRequestDTO:BaseProduct
    {
        public UpdateProductRequestDTO(string name, string description, double price, int quantity, string brand) : base(name, description, price, quantity, brand)
        {
            this.Name = name;
            this.Description = description;
            this.Price = price;
            this.Quantity = quantity;
            this.Brand = brand;
        }
        public UpdateProductRequestDTO(CreateProductRequestDTO productDTO) : base(productDTO.Name, productDTO.Description, productDTO.Price, productDTO.Quantity, productDTO.Brand)
        {
            this.Name = productDTO.Name;
            this.Description = productDTO.Description;
            this.Price = productDTO.Price;
            this.Quantity = productDTO.Quantity;
            this.Brand = productDTO.Brand;
        }
        public UpdateProductRequestDTO()
        {

        }
    }

}
