using System;
using System.Collections.Generic;
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
            double cost = costCalculator.GetCost(new Parcel { Length = 0, Width = 0, Depth = 0 });
            Assert.AreEqual(3, cost);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "All dimensions must be positive")]
        public void Exception()
        {
            FixedDeliveryCostCalculator costCalculator = new FixedDeliveryCostCalculator();
            double cost = costCalculator.GetCost(new Parcel { Length = -1, Width = 0, Depth = 0 });
        }

        [TestMethod]
        public void Medium()
        {
            FixedDeliveryCostCalculator costCalculator = new FixedDeliveryCostCalculator();
            double cost = costCalculator.GetCost(new Parcel { Length = 10, Width = 0, Depth = 0 });
            Assert.AreEqual(8, cost);
        }

        [TestMethod]
        public void Large()
        {
            FixedDeliveryCostCalculator costCalculator = new FixedDeliveryCostCalculator();
            double cost = costCalculator.GetCost(new Parcel { Length = 0, Width = 50, Depth = 0 });
            Assert.AreEqual(15, cost);
        }

        [TestMethod]
        public void Largest()
        {
            FixedDeliveryCostCalculator costCalculator = new FixedDeliveryCostCalculator();
            double cost = costCalculator.GetCost(new Parcel { Length = 0, Width = 0, Depth = 100 });
            Assert.AreEqual(25, cost);
        }

        [TestMethod]
        public void OrderCost()
        {
            Order order = new Order();
            order.Parcels = new List<Parcel>
            {
                new Parcel
                {
                    Length = 5,
                    Width = 5,
                    Depth = 5
                },
                new Parcel
                {
                    Length = 100,
                    Width = 100,
                    Depth = 100
                }
            };

            double cost = order.Cost;
            Assert.AreEqual(28, cost);
            Assert.AreEqual(3, order.Parcels[0].Cost);
            Assert.AreEqual(25, order.Parcels[1].Cost);
        }

        [TestMethod]
        public void OrderCostSpeedy()
        {
            Order order = new Order { Speedy = true };
            order.Parcels = new List<Parcel>
            {
                new Parcel
                {
                    Length = 5,
                    Width = 5,
                    Depth = 5
                },
                new Parcel
                {
                    Length = 100,
                    Width = 100,
                    Depth = 100
                }
            };

            double cost = order.Cost;
            Assert.AreEqual(56, cost);
            Assert.AreEqual(3, order.Parcels[0].Cost);
            Assert.AreEqual(25, order.Parcels[1].Cost);
        }

        [TestMethod]
        public void SmallestOverweight()
        {
            FixedDeliveryCostCalculator costCalculator = new FixedDeliveryCostCalculator();
            double cost = costCalculator.GetCost(new Parcel { Length = 0, Width = 0, Depth = 0, Weight = 1.1 });
            Assert.AreEqual(5.2, cost);
        }

        [TestMethod]
        public void MediumOverweight()
        {
            FixedDeliveryCostCalculator costCalculator = new FixedDeliveryCostCalculator();
            double cost = costCalculator.GetCost(new Parcel { Length = 10, Width = 0, Depth = 0, Weight = 3.1 });
            Assert.AreEqual(14.2, cost);
        }

        [TestMethod]
        public void LargeOverweight()
        {
            FixedDeliveryCostCalculator costCalculator = new FixedDeliveryCostCalculator();
            double cost = costCalculator.GetCost(new Parcel { Length = 0, Width = 50, Depth = 0, Weight = 6.1 });
            Assert.AreEqual(27.2, cost);
        }

        [TestMethod]
        public void LargestOverweight()
        {
            FixedDeliveryCostCalculator costCalculator = new FixedDeliveryCostCalculator();
            double cost = costCalculator.GetCost(new Parcel { Length = 0, Width = 0, Depth = 100, Weight = 10.1 });
            Assert.AreEqual(45.2, cost);
        }
    }
}
