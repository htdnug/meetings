using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpecificationPattern.Library;

namespace SpecificationPattern.Tests
{
    [TestClass]
    public class OrderTests
    {
        [TestMethod]
        public void IsRush_NonDomesticOrder_ShouldBeFalse()
        {
            var order = new Order
            {
                ShippingAddress = this.GetInternationalAddress()
            };
            Assert.IsFalse(order.IsRush);
        }

        [TestMethod]
        public void IsRush_Under100Dollars_ShouldBeFalse()
        {
            var order = new Order 
                { 
                    OrderTotal = 50, 
                    ShippingAddress = this.GetDomesticAddress()
                };
            Assert.IsFalse(order.IsRush);
        }

        [TestMethod]
        public void IsRush_ContainsOutOfStockProduct_ShouldBeFalse()
        {
            bool isInStock = false;
            bool isHazard = false;
            var order = new Order
                {
                    OrderTotal = 200,
                    ShippingAddress = this.GetDomesticAddress()
                };
            Product product = this.GetProduct(isInStock, isHazard);
            order.OrderItems.Add(product);
            Assert.IsFalse(order.IsRush);
        }

        [TestMethod]
        public void IsRush_ContainsHazardousProduct_ShouldBeFalse()
        {
            bool isInStock = true;
            bool isHazard = true;
            var order = new Order
            {
                OrderTotal = 200,
                ShippingAddress = this.GetDomesticAddress()
            };
            Product product = this.GetProduct(isInStock, isHazard);
            order.OrderItems.Add(product);
            Assert.IsFalse(order.IsRush);
        }

        [TestMethod]
        public void IsRush_AllConditionsMet_ShouldBeTrue()
        {
            bool isInStock = true;
            bool isHazard = false;
            var order = new Order
            {
                OrderTotal = 200,
                ShippingAddress = this.GetDomesticAddress()
            };
            Product product = this.GetProduct(isInStock, isHazard);
            order.OrderItems.Add(product);
            Assert.IsTrue(order.IsRush);
        }

        private Address GetInternationalAddress()
        {
            return new Address { Country = "!USA" };
        }

        private Address GetDomesticAddress()
        {
            return new Address { Country = "USA" };
        }

        private Product GetProduct(bool isInStock, bool isHazard)
        {
            return new Product { ContainsHazardousMaterial = isHazard, IsInStock = isInStock };
        }
    }
}
