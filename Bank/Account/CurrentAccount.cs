using System;
using System.Threading.Tasks;

using Bank.Exceptions;

namespace Bank.Account
{
    public class CurrentAccount : AccountBase
    {
        public CurrentAccount(int accountNumber) : base(accountNumber)
        { }

        protected override bool VerifyWithdrawAmount(decimal amount)
        {
            return OverdraftLimit <= Balance - amount && amount > 0;
        }
    }
}