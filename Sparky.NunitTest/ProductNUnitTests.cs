using NUnit.Framework;

namespace Sparky.NunitTest
{
    [TestFixture]
    public class ProductNUnitTests
    {
        [Test]
        public void GetPrductPrice_PlatinumCustomer_ReturnPriceWith20Discount()
        {
            Product product = new Product();

            var result = product.GetPrice(new Customer() { IsPlatinum = true});

            Assert.That(result, Is.EqualTo(40));
        }
    }
}
