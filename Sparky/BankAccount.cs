namespace Sparky
{
    public class BankAccount
    {
        private readonly ILogBook _logBook;

        public int Balance { get; set; }
        public BankAccount(ILogBook logBook)
        {
            Balance = 0;
            _logBook = logBook;
        }

        public bool Deposite(int amount)
        {
            _logBook.Message("Deposit invocked"); 
            Balance += amount;
            return true;
        }

        public bool Withdraw(int amount)
        {
            if(amount <= Balance)
            {
                _logBook.LogToDb($"Withdrawal amount is {amount}");
                Balance -= amount;
                return _logBook.LogBalanceAfterWithdraw(Balance);
            }
            return false;
        }

        public int GetBalance()
        { 
            return Balance; 
        }
    }
}
