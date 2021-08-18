using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankActApp
{
    class LineOfCreditAccount : BankAccount
    {
        public LineOfCreditAccount(string name, decimal initialBalance, decimal creditLimit) : base(name, initialBalance, -creditLimit)
        {
           
        }

        public override void PerformMonthEndTransactions()
        {
            if (Balance < 0)
            {
                // Negate the balance to get a positive interest charge:
                var interest = -Balance * 0.07m;
                MakeWithdrawal(interest, DateTime.Now, "Charge monthly interest");
            }
        }
        // <AddOverdraftFee>
        protected override Transaction CheckWithdrawalLimit(bool isOverdrawn)
        {
            return isOverdrawn ? new Transaction(-20, DateTime.Now, "Apply overdraft fee") : default;
        }
        // </AddOverdraftFee>
    }
}
