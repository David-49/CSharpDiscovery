using System;
using System.Threading.Tasks;

using Bank.Exceptions;

namespace Bank.Account
{
    public abstract class AccountBase : IAccount
    {
        private bool _isLocked;

        public int AccountNumber { get; } = 0;

        public AccountBase(int accountNumber)
        {
            AccountNumber = accountNumber;
        }
		
		public virtual decimal OverdraftLimit { get; set; }
		
        public decimal Balance { get; private set; }
		
        public async Task DepositAsync(decimal amount)
        {
            if (_isLocked) throw new UnauthorizedAccountOperationException();
			if (amount < 0) throw new UnauthorizedAccountOperationException();

            Balance += amount;
        }

		public async Task WithdrawAsync(decimal amount)
        {
            if (_isLocked) throw new UnauthorizedAccountOperationException();
            if (!VerifyWithdrawAmount(amount)) throw new UnauthorizedAccountOperationException();
            Balance -= amount;
        }

        public void OnLockDownStarted(object sender, EventArgs e)
        {
            _isLocked = true;
        }

        public void OnLockDownEnded(object sender, EventArgs e)
        {
            _isLocked = false;
        }

        protected abstract bool VerifyWithdrawAmount(decimal amount);
    }
}