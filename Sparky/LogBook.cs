using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparky
{
    public interface ILogBook
    {
        int LogSeverity { get; set; }
        string LogType { get; set; }

        void Message(string message);
        bool LogToDb(string message);
        bool LogBalanceAfterWithdraw(int balanceAfterWithdraw);
        string MessageWithReturnStr(string message);
        bool LogWithOutputResult(string message, out string outputStr);

        bool LogWithRefObject(ref Customer customer);
    }
    public class LogBook : ILogBook
    {
        public int LogSeverity { get; set; }
        public string LogType { get; set; }

        public bool LogBalanceAfterWithdraw(int balanceAfterWithdraw)
        {
            if(balanceAfterWithdraw >= 0)
            {
                Console.WriteLine("Success");
                return true;
            }

            Console.WriteLine("Failure");
            return false;
        }

        public bool LogToDb(string message)
        {
            Console.WriteLine(message);
            return true;
        }

        public bool LogWithOutputResult(string message, out string outputStr)
        {
            outputStr = "Hello " + message;
            return true;
        }

        public bool LogWithRefObject(ref Customer customer)
        {
            return true;
        }

        public void Message(string message)
        {
           Console.WriteLine(message);
        }

        public string MessageWithReturnStr(string message)
        {
            Console.WriteLine(message);
            return message.ToLower();
        }


    }
}
