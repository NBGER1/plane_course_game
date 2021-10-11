using Infrastructure.Events;

namespace Gameplay.EventParamsDir
{
    public class OnAmmoChangeEventParams : EventParams
    {
        #region Fields

        private int _ammo;

        #endregion

        #region Constructor

        public OnAmmoChangeEventParams(int ammo)
        {
            _ammo = ammo;
        }

        #endregion

        #region Properties

        public int Ammo => _ammo;

        #endregion
    }
}