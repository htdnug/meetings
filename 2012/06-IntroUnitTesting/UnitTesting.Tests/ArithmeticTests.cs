using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTesting.Tests
{
    [TestClass]
    public class ArithmeticTests
    {
        [TestMethod]
        public void Add_ValidNumbers_CalculatedValue()
        {
            // arrange
            decimal left = 1;
            decimal right = 2;

            // act 
            decimal actual = Arithmetic.Add(left, right);

            // assert
            Assert.AreEqual(3, actual);
        }

        [TestMethod]
        public void Divide_ValidNumber_CalculatedValue()
        {
            // arrange
            decimal left = 6;
            decimal right = 2;

            // act 
            decimal actual = Arithmetic.Divide(left, right);

            // assert
            Assert.AreEqual(3, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void Divide_ZeroRightSide_DivideByZeroException()
        {
            // arrange
            decimal left = 1;
            decimal right = 0;

            // act 
            decimal actual = Arithmetic.Divide(left, right);

            // assert - no assertion when using ExpectedException
        }

        [TestMethod]
        public void Multiply_ValidNumber_CalculatedValue()
        {
            // arrange
            decimal left = 7;
            decimal right = 4;

            // act 
            decimal actual = Arithmetic.Multiply(left, right);

            // assert
            Assert.AreEqual(28, actual);
        }

        [TestMethod]
        public void Subtract_ValidNumber_CalculatedValue()
        {
            // arrange
            decimal left = 8;
            decimal right = 3;

            // act 
            decimal actual = Arithmetic.Subtract(left, right);

            // assert
            Assert.AreEqual(5, actual);
        }
    }
}
