using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WK.POS.Models
{
    public class Product: BaseModel
    {
        /// <summary>
        /// gets and sets  the code
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// gets and sets the unit price
        /// </summary>
        public decimal UnitPrice { get; set; }
        /// <summary>
        /// gets and sets builk price
        /// </summary>
        public ProductBulkPricing BulkPrice { get; set; }

    }
}
