using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WK.POS.Interfaces;
using WK.POS.Models;
using WK.POS.Models.Helpers;

namespace WK.POS.Services
{
    public class PointOfSaleTerminalService : IPointOfSaleTerminal
    {
        private readonly List<Product> _products;
        public PointOfSaleTerminalService()
        {
            _products = ProductSeeder.Seed();
        }

        /// <summary>
        /// setting up the prices of the products
        /// </summary>
        /// <param name="products"></param>
        /// <returns></returns>
        public List<Product> SetPricing(List<Product> products)
        {
            foreach (var product in products)
            {
                if (_products != null && product != null && !string.IsNullOrWhiteSpace(product.Code))
                {
                    Product prod = _products.FirstOrDefault(p => p.Code == product.Code);
                    if (prod != null)
                    {
                        prod.UnitPrice = product.UnitPrice;
                        prod.BulkPrice = product.BulkPrice;
                    }

                }
            }
            return _products;
        }

        /// <summary>
        /// scans the product on product code
        /// </summary>
        /// <param name="productCode"></param>
        /// <returns></returns>
        public Product Scan(string productCode)
        {
            Product result = null;
            if (_products != null && !string.IsNullOrWhiteSpace(productCode))
            {
                result = _products.FirstOrDefault(x => x.Code == productCode);
            }
            return result;
        }

        /// <summary>
        /// Calcuates the price of the product on product code
        /// </summary>
        /// <param name="productCodes"></param>
        /// <returns></returns>
        public decimal CalculateTotal(List<string> productCodes)
        {
            try
            {
                if (productCodes != null && productCodes.Count > 0)
                {
                    decimal finalPrice = 0.0M;
                    var result = productCodes.GroupBy(p => p);
                    List<KeyValuePair<string, int>> groupedProducts = result.Select(p => new KeyValuePair<string, int>(p.Key, p.ToList().Count)).ToList();
                    foreach (var prod in groupedProducts)
                    {
                        var scannedProduct = Scan(prod.Key);
                        decimal productPrice = 0.0M;
                        if (scannedProduct.BulkPrice != null)
                        {
                            int q = (prod.Value) / scannedProduct.BulkPrice.BulkQuantity;
                            int r = (prod.Value) % scannedProduct.BulkPrice.BulkQuantity;
                            if (q >= 1)
                            {
                                productPrice = (1 * scannedProduct.BulkPrice.BulkPrice) + ((q - 1) * scannedProduct.BulkPrice.BulkQuantity * scannedProduct.UnitPrice) + (r * scannedProduct.UnitPrice);
                                finalPrice = productPrice + finalPrice;
                            }
                            else
                            {
                                productPrice = (prod.Value * scannedProduct.UnitPrice);
                                finalPrice = productPrice + finalPrice;
                            }
                        }
                        else
                        {
                            productPrice = (prod.Value * scannedProduct.UnitPrice);
                            finalPrice = productPrice + finalPrice;
                        }

                    }

                    return finalPrice;
                }
                return 0;
            }catch(Exception ex)
            {
                throw new Exception(
                   $"CalculateTotal service method Failed!",ex);
            }
           
        }

    }
}
