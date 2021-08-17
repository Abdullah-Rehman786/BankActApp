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
            Console.ReadLine(); //prevent console from exiting
        }
    }
}
