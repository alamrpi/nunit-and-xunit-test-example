using NUnit.Framework;

namespace Sparky.NunitTest
{
    [TestFixture]
    public class CalculatorNUnitTests
    {
        private Calculator calculator;
        [SetUp] 
        public void SetUp() { 
            calculator = new Calculator();
        }

        [Test]
        public void AddNumbers_InpurTwoInt_GetCorrectAddition()
        {
            //Act
            int result = calculator.AddNumber(10, 20);

            //Assert
            Assert.AreEqual(30, result);
        }

        [Test]
        [TestCase(11)]
        [TestCase(13)]
        public void IsOddNumber_InputAnNumber_ReturnTrue(int a)
        {
            //Act
            bool result = calculator.IsOddNumber(a);

            //Assert
            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        [TestCase(11, ExpectedResult = true)]
        [TestCase(12, ExpectedResult = false)]
        public bool IsOddChecker_InputANumber_ReturnTestResult(int a)
        {
            return calculator.IsOddNumber(a);
        }

        [Test]
        [TestCase(5.4, 10.5)] //15.9
        [TestCase(5.43, 10.53)] //15.93
        [TestCase(5.49, 10.59)] //16.08
        public void AddNumbers_InpurTwoDouble_GetCorrectAddition(double a, double b)
        {
            //Act
            double result = calculator.AddNumber(a, b);

            //Assert
            Assert.AreEqual(15.9, result, 1);
        }

        [Test]
        public void OddRange_InputMinAndMax_ReturnOddNumbers()
        {
            List<int> expectedResult = new() { 5, 7, 9};

            //act
            List<int> result = calculator.GetOddRange(5, 10);

            //Assert
            Assert.That(result, Is.EquivalentTo(expectedResult));
        }


    }
}
