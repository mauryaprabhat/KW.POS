using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WK.POS.Models.Helpers
{
    public static class ProductSeeder
    {
        public static List<Product> Seed()
        {
            return new List<Product>() {
                new Product (){ Id=1, Code="A",UnitPrice= 1.25M,
                    BulkPrice = new ProductBulkPricing(){
                        BulkQuantity=3, BulkPrice=3.00M
                    }
                },
                new Product (){ Id=1, Code="B",UnitPrice= 4.25M },
                new Product (){ Id=1, Code="C",UnitPrice= 1.00M,
                BulkPrice = new ProductBulkPricing(){
                        BulkQuantity=6, BulkPrice=5.00M
                    }
                },
                new Product (){ Id=1, Code="D",UnitPrice= 0.75M }
            };
        }
    }
}
