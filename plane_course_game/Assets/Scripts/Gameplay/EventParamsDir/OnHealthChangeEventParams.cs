using Infrastructure.Events;

namespace Gameplay.EventParamsDir
{
    public class OnHealthChangeEventParams : EventParams
    {
        #region Fields

        private float _health;
        #endregion

        #region Constructor

        public OnHealthChangeEventParams(float health)
        {
            _health = health;
        }

        #endregion

        #region Properties

        public float Health => _health;

        #endregion
    }
}