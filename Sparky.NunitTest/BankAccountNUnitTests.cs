using Moq;
using NUnit.Framework;

namespace Sparky.NunitTest
{
    [TestFixture]
    public class BankAccountNUnitTests
    {
        private BankAccount _bankAccount;

        [SetUp] 
        public void SetUp() {
            _bankAccount = new(new LogBook());
        }

        [Test]
        public void BankDeposit_Add100_ReturnTrue()
        {
           bool result = _bankAccount.Deposite(100);

            //assert
            Assert.Multiple(() =>
            {
                Assert.IsTrue(result);
                Assert.That(_bankAccount.GetBalance(), Is.EqualTo(100));
            });
        }

        [Test]
        public void BankDeposit_Add100_ReturnTrue_2()
        {
            var logMock = new Mock<ILogBook>();
            logMock.Setup(x => x.Message("Deposit done"));

            var bankAccount = new BankAccount(logMock.Object);
            bool result = bankAccount.Deposite(100);

            //assert
            Assert.Multiple(() =>
            {
                Assert.IsTrue(result);
                Assert.That(bankAccount.GetBalance(), Is.EqualTo(100));
            });
        }

        [Test]
        [TestCase(200, 100)]
        [TestCase(300, 200)]
        public void BankWithdraw_Withdraw100With200Balance_ReturnsTrue(int balance, int withdraw)
        {
            var logMoq = new Mock<ILogBook>();
            logMoq.Setup(u => u.LogToDb(It.IsAny<string>())).Returns(true);
            logMoq.Setup(u => u.LogBalanceAfterWithdraw(It.Is<int>(x => x > 0))).Returns(true);

            BankAccount bankAccount = new BankAccount(logMoq.Object);
            bankAccount.Deposite(balance);
            var result = bankAccount.Withdraw(withdraw);
            Assert.True(result);
        }
    }
}
