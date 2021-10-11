using Infrastructure.Events;

namespace Gameplay.EventParamsDir
{
    public class OnPlayerTakeDamageEventParams : EventParams
    {
        #region Fields

        private float _damage;

        #endregion

        #region Constructor

        public OnPlayerTakeDamageEventParams(float damage)
        {
            _damage = damage;
        }

        #endregion

        #region Properties

        public float Damage => _damage;

        #endregion
    }
}