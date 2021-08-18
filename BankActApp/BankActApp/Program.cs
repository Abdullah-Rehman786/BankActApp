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

            /* Test that the initial balances must be positive.
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
            */

            /* Test for a negative balance.
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
            */

            Console.WriteLine(account.GetAccountHistory());
            Console.ReadLine();

            //test GiftCardAccount
            var giftCard = new GiftCardAccount("gift card", 100, 50);
            giftCard.MakeWithdrawal(20, DateTime.Now, "get expensive coffee");
            giftCard.MakeWithdrawal(50, DateTime.Now, "buy groceries");
            giftCard.PerformMonthEndTransactions();

            // can make additional gift card deposits:
            giftCard.MakeDeposit(27.50m, DateTime.Now, "add some additional spending money");
            Console.WriteLine(giftCard.GetAccountHistory());
            Console.ReadLine();

            //test InterestEarningAccount
            var savings = new InterestEarningAccount("savings account", 10000);
            savings.MakeDeposit(750, DateTime.Now, "save some money");
            savings.MakeDeposit(1250, DateTime.Now, "Add more savings");
            savings.MakeWithdrawal(250, DateTime.Now, "Needed to pay monthly bills");
            savings.PerformMonthEndTransactions();
            Console.WriteLine(savings.GetAccountHistory());
            Console.ReadLine();

            //test LineofCreditAccount
            var lineOfCredit = new LineOfCreditAccount("line of credit", 0, 5000);
            // How much is too much to borrow?
            lineOfCredit.MakeWithdrawal(1000m, DateTime.Now, "Take out monthly advance");
            lineOfCredit.MakeDeposit(50m, DateTime.Now, "Pay back small amount");
            lineOfCredit.MakeWithdrawal(5000m, DateTime.Now, "Emergency funds for repairs");
            lineOfCredit.MakeDeposit(150m, DateTime.Now, "Partial restoration on repairs");
            lineOfCredit.PerformMonthEndTransactions();
            Console.WriteLine(lineOfCredit.GetAccountHistory());

            Console.ReadLine(); //prevent console from exiting

            var integerList = new int[] { 1, 1, 2, 3, 1, 2, 3, 4 };
            var valuesList = new int[] { 2, 3 }; 

                var intList = integerList.ToList();
                for (int i = 0; i < valuesList.Length; i++)
                {

                    intList.RemoveAll(item => item == valuesList[i]);
                }
                Console.Write(intList);
               

            
        }
    }
}
