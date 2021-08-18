using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace BankActApp
{
    class Program
    {
        static void Main(string[] args)
        {
            BankAccount account  = new BankAccount("Abdullah", 1000);

            Console.WriteLine($"Account {account.Number} was created for {account.Owner} with {account.Balance} initial balance.");

            account.MakeWithdrawal(500, DateTime.Now, "Rent payment");
            Console.WriteLine(account.Balance);

            account.MakeDeposit(100, DateTime.Now, "Friend paid me back");
            Console.WriteLine(account.Balance);

            // Test that the initial balances must be positive.
            BankAccount invalidAccount;
            try
            {
                invalidAccount = new BankAccount("invalid", -55);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("Exception caught creating account with negative balance");
                Console.WriteLine(e.ToString());
                Console.ReadLine();
            }

            // Test for a negative balance.
            try
            {
                account.MakeWithdrawal(750, DateTime.Now, "Attempt to overdraw");
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("Exception caught trying to overdraw");
                Console.WriteLine(e.ToString());
                Console.ReadLine();
            }

            Console.WriteLine(account.GetAccountHistory());
            Console.ReadLine();


            Console.ReadLine(); //prevent console from exiting
        }
    }
}
