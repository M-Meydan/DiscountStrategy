using BEIS.Models;
using System;
using System.Globalization;

namespace BEIS
{
    public interface IProductValidator
    {
        Product ConvertToProduct(ProductDTO productDTO);
    }

    public class ProductValidator : IProductValidator
    {
        public Product ConvertToProduct(ProductDTO productDTO)
        {
            float price;

            if (string.IsNullOrEmpty(productDTO.Id)) throw new ArgumentException($"Product Id is invalid {productDTO.Id}");
            else if (string.IsNullOrEmpty(productDTO.ProductType)) throw new ArgumentException($"Product Type is invalid {productDTO.ProductType}");
            else
            {
                var allowedSyles = NumberStyles.AllowCurrencySymbol | NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands;

                if (!float.TryParse(productDTO.Price, allowedSyles, CultureInfo.GetCultureInfo("EN-GB"), out price))
                    throw new ArgumentException($"Product Price is invalid {productDTO.Price}");
            }

            return new Product(productDTO.Id, productDTO.ProductType, price);
        }
    }
}