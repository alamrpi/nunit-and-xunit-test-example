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

        [Test]
        [TestCase(200, 300)]
        public void BankWithdraw_Withdraw300With200Balance_ReturnsFalse(int balance, int withdraw)
        {
            var logMoq = new Mock<ILogBook>();
            logMoq.Setup(u => u.LogBalanceAfterWithdraw(It.Is<int>(x => x > 0))).Returns(true);
            //logMoq.Setup(u => u.LogBalanceAfterWithdraw(It.Is<int>(x => x < 0))).Returns(false);
            logMoq.Setup(u => u.LogBalanceAfterWithdraw(It.IsInRange(int.MinValue, -1, Moq.Range.Inclusive))).Returns(false);

            BankAccount bankAccount = new BankAccount(logMoq.Object);
            bankAccount.Deposite(balance);
            var result = bankAccount.Withdraw(withdraw);
            Assert.IsFalse(result);
        }

        [Test]
        public void BankLogDummy_LogMockString_ReturnTrue()
        {
            var logMoq = new Mock<ILogBook>();
            string desiredOutput = "hello";

            logMoq.Setup(u => u.MessageWithReturnStr(It.IsAny<string>())).Returns((string str) => str.ToLower());
           
            Assert.That(logMoq.Object.MessageWithReturnStr("Hello"), Is.EqualTo(desiredOutput));
        }

        [Test]
        public void BankLogDummy_LogMockStringOutPutStr_ReturnTrue()
        {
            var logMoq = new Mock<ILogBook>();
            string desiredOutput = "hello";

            logMoq.Setup(u => u.LogWithOutputResult(It.IsAny<string>(), out desiredOutput)).Returns(true);
            string result = "";
            Assert.Multiple(() =>
            {
                Assert.IsTrue(logMoq.Object.LogWithOutputResult("Ben", out result));
                Assert.That(result, Is.EqualTo(desiredOutput));
            });
        }

        [Test]
        public void BankLogDummy_LogRefChecker_ReturnTrue()
        {
            var logMoq = new Mock<ILogBook>();
            
            Customer customer = new();
            Customer customerNotUsed = new();

            logMoq.Setup(u => u.LogWithRefObject(ref customer)).Returns(true);

            Assert.IsFalse(logMoq.Object.LogWithRefObject(ref customerNotUsed));
            Assert.IsTrue(logMoq.Object.LogWithRefObject(ref customer));
        }

        [Test]
        public void BankLogDummy_SetAndGetLogTypeAndSeveirtyMock_MockTest()
        {
            var logMoq = new Mock<ILogBook>();
         
            logMoq.Setup(u => u.LogSeverity).Returns(10);
            logMoq.Setup(u => u.LogType).Returns("warning");

            //For setup all properties
            //logMoq.SetupAllProperties();

            //for setup single property
            logMoq.SetupProperty(x => x.LogSeverity);
            logMoq.Object.LogSeverity = 100;

            Assert.Multiple(() =>
            {
                Assert.That(logMoq.Object.LogSeverity, Is.EqualTo(100));
                Assert.That(logMoq.Object.LogType, Is.EqualTo("warning"));
            });
        }
    }
}
