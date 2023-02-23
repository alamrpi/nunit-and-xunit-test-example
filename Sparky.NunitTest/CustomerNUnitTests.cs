using NUnit.Framework;

namespace Sparky.NunitTest
{
    [TestFixture]
    public class CustomerNUnitTests
    {
        private Customer customer;

        [SetUp]
        public void SetUp() {
            customer = new();
        }

        [Test]
        [TestCase("Md", "Alam")]
        public void GetFullName_InputFirstAndLastName_ReturnFullName(string firstName, string lastName)
        {
            //Act
            string fullName = customer.GetFullName(firstName, lastName);

            //Assert 
            Assert.Multiple(() =>
            {
                Assert.AreEqual(fullName, "Md Alam");
                Assert.That(fullName, Is.EqualTo("Md Alam"));
                Assert.That(fullName, Does.Contain("Md"));
                Assert.That(fullName, Does.StartWith("Md"));
                Assert.That(fullName, Does.EndWith("Alam"));
                //Assert.That(fullName, Does.Match(""));
            });
        }

        [Test]
        public void DiscountCheck_DefaultCustomer_ReturnsDiscountInRange()
        {
            int result = customer.Discount;

            //Act\
            Assert.That(result, Is.InRange(10, 25));
        }
    }
}
