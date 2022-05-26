using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTesting.Tests
{
    [TestClass]
    public class CircleTests
    {
        [TestMethod]
        public void CalculatePerimeter_ValidRadius_ValidPerimeter()
        {
            // arrange
            double radius = 5;
            Circle circle = new Circle();

            // act 
            double actual = circle.CalculatePerimeter(radius);

            // assert
            Assert.AreEqual(31.42, Math.Round(actual, 2));
        }

        [TestMethod]
        public void CalculateArea_ValidRadius_ValidArea()
        {
            // arrange
            double radius = 5;
            Circle circle = new Circle();

            // act 
            double actual = circle.CalculateArea(radius);

            // assert
            Assert.AreEqual(78.54, Math.Round(actual, 2));
        }

        [TestMethod]
        public void CalculateDiameter_ValidRadius_ValidDiameter()
        {
            // arrange
            double radius = 5;
            Circle circle = new Circle();

            // act 
            double actual = circle.CalculateDiameter(radius);

            // assert
            Assert.AreEqual(10, actual);
        }
    }
}
