

namespace Sparky.MSTest
{
    [TestClass]
    public class CalculatorMsTests
    {
        [TestMethod]
        public void AddNumbers_InpurTwoInt_GetCorrectAddition()
        {
            //Arrange
            Calculator calculator= new();

            //Act
            int result = calculator.AddNumber(10, 20);

            //Assert
            Assert.AreEqual(30, result);
        }
    }
}
