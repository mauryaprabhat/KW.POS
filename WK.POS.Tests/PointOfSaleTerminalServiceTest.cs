using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WK.POS.Interfaces;
using WK.POS.Services;

namespace WK.POS.Tests
{
    [TestClass]
    public class PointOfSaleTerminalServiceTest
    {
        private IPointOfSaleTerminal _pointOfSaleTerminal;
        public PointOfSaleTerminalServiceTest(IPointOfSaleTerminal pointOfSaleTerminal)
        {
            this._pointOfSaleTerminal = pointOfSaleTerminal;
        }

        [TestMethod]
        [Owner(@"Maurya, Prabhat")]
        public void Test_Calculate_Total_Method()
        {
            List<string> productsList = new List<string>() { "A", "B", "C", "D", "A", "B", "A" };
            decimal finalPrice = 13.25M;
          //  PointOfSaleTerminalService posService = new PointOfSaleTerminalService();
            decimal result = _pointOfSaleTerminal.CalculateTotal(productsList);

            Assert.AreEqual(result,finalPrice);
        }

    }
}
