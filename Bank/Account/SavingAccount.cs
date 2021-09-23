using System;
using System.Threading.Tasks;

using Bank.Exceptions;

namespace Bank.Account
{
    public class SavingAccount : AccountBase
    {
        public SavingAccount(int accountNumber) : base(accountNumber)
        { }

        public override decimal OverdraftLimit 
        { 
            get => 0;
            set => throw new UnauthorizedAccountOperationException();
        }

        protected override bool VerifyWithdrawAmount(decimal amount)
        {
            return Balance * 0.1M >= amount  && amount > 0;
        }
    }
}