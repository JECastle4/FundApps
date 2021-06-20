using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FundApps.Controllers;

namespace CourierKataTests
{
    [TestClass]
    public class CourierKataTests
    {
        [TestMethod]
        public void Smallest()
        {
            FixedDeliveryCostCalculator costCalculator = new FixedDeliveryCostCalculator();
            double cost = costCalculator.GetCost(0, 0, 0);
            Assert.AreEqual(3, cost);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "All dimensions must be positive")]
        public void Exception()
        {
            FixedDeliveryCostCalculator costCalculator = new FixedDeliveryCostCalculator();
            double cost = costCalculator.GetCost(-1, 0, 0);            
        }

        [TestMethod]
        public void Medium()
        {
            FixedDeliveryCostCalculator costCalculator = new FixedDeliveryCostCalculator();
            double cost = costCalculator.GetCost(10, 0, 0);
            Assert.AreEqual(8, cost);
        }

        [TestMethod]
        public void Large()
        {
            FixedDeliveryCostCalculator costCalculator = new FixedDeliveryCostCalculator();
            double cost = costCalculator.GetCost(0, 50, 0);
            Assert.AreEqual(15, cost);
        }

        [TestMethod]
        public void Largest()
        {
            FixedDeliveryCostCalculator costCalculator = new FixedDeliveryCostCalculator();
            double cost = costCalculator.GetCost(0, 0, 100);
            Assert.AreEqual(25, cost);
        }
    }
}
