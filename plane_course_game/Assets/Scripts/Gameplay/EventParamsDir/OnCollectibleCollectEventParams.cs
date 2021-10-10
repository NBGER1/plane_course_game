using Infrastructure.Events;
using UnityEngine;

namespace Gameplay.EventParamsDir
{
    public class OnCollectibleCollectEventParams : EventParams
    {
        #region Fields

        private Vector3 _position;
        private float _amount;
        #endregion

        #region Constructor

        public OnCollectibleCollectEventParams(Vector3 position,float amount)
        {
            _position = position;
            _amount =amount;
        }

        #endregion

        #region Properties

        public Vector3 Position => _position;
        public float Amount => _amount;

        #endregion
    }
}