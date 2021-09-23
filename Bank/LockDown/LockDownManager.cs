using System;

namespace Bank.LockDown
{
    public class LockDownManager : ILockDownManager
    {
        private bool _isLocked;

        public event EventHandler LockDownStarted;

		public event EventHandler LockDownEnded;

		public void StartLockDown()
        {
           if(!_isLocked)
           {
               OnLockDownStarted();
               _isLocked = true;
           }
        }

		public void EndLockDown()
        {
            if(_isLocked)
            {
                OnEndLockDown();
                _isLocked = false;
            }
        }

        protected virtual void OnLockDownStarted()
        {
            LockDownStarted?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnEndLockDown()
        {
            LockDownEnded?.Invoke(this, EventArgs.Empty);
        }
    }

}