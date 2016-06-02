using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTesting.Tests
{
    [TestClass]
    public class CarTests
    {
        [TestMethod]
        public void CopyConstructor_CorrectlyCopiesDataAndCreatesNewInstance()
        {
            // arrange
            Car one = new Car();
            one.Color = "red";
            one.Make = "gmc";

            // act 
            Car two = new Car(one);

            // assert
            Assert.AreNotSame(two, one);
            Assert.AreEqual("red", two.Color);
            Assert.AreEqual("gmc", two.Make);
        }
    }
}
