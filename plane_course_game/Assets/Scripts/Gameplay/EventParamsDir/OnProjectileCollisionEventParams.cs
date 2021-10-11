using Infrastructure.Events;
using UnityEngine;

namespace Gameplay.EventParamsDir
{
    public class OnProjectileCollisionEventParams : EventParams
    {
        #region Fields

        private Vector3 _position;
        #endregion

        #region Constructor

        public OnProjectileCollisionEventParams(Vector3 position)
        {
            _position = position;
        }

        #endregion

        #region Properties

        public Vector3 Position => _position;

        #endregion
    }
}