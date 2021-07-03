using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WK.POS.Models
{
   public class ProductBulkPricing
    {
        /// <summary>
        /// gets and sets the bulk quantity
        /// </summary>
        public int BulkQuantity { get; set; }
        /// <summary>
        /// gets and sets the bulk prices
        /// </summary>
        public decimal BulkPrice { get; set; }
    }
}
