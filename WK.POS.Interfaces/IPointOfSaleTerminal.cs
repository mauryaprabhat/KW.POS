using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WK.POS.Models;

namespace WK.POS.Interfaces
{
    public interface IPointOfSaleTerminal
    {
        /// <summary>
        /// setting up the prices of the products
        /// </summary>
        /// <param name="products"></param>
        /// <returns></returns>
        List<Product> SetPricing(List<Product> products);
        /// <summary>
        /// scans the product on product code
        /// </summary>
        /// <param name="productCode"></param>
        /// <returns></returns>
        Product Scan(string productCode);
        /// <summary>
        /// Calcuates the price of the product on product code
        /// </summary>
        /// <param name="productsCode"></param>
        /// <returns></returns>
        decimal CalculateTotal(List<string> productsCode);
    }
}
