using Infrastructure.Events;

namespace Gameplay.EventParamsDir
{
    public class OnPlayerBalanceChangeEventParams : EventParams
    {
        #region Fields

        private int _oldBalance;
        private int _balance;

        #endregion

        #region Methods

        public OnPlayerBalanceChangeEventParams(int oldBalance, int balance)
        {
            _oldBalance = oldBalance;
            _balance = balance;
        }

        #endregion

        #region Properties

        public int Balance => _balance;
        public int OldBalance => _oldBalance;

        #endregion
    }
}