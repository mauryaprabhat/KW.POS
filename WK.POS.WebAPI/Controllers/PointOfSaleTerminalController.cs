using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WK.POS.Interfaces;
using WK.POS.Services;

namespace WK.POS.WebAPI.Controllers
{
    [RoutePrefix("api/v1/pointOfSaleTerminal")]
    public class PointOfSaleTerminalController : ApiController
    {
        private readonly IPointOfSaleTerminal _pointOfSaleTerminal;
        public PointOfSaleTerminalController(IPointOfSaleTerminal pointOfSaleTerminal)
        {
            this._pointOfSaleTerminal = pointOfSaleTerminal;
            
        }

        /// <summary>
        /// calculateProductTotalPrice to calculate the product price
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        [Route("calculateProductTotalPrice")]
        public decimal CalculateTotal()
        {
            return  _pointOfSaleTerminal.CalculateTotal(new List<string>() { "A", "B", "C", "D", "A", "B", "A" });
        }

    }
}