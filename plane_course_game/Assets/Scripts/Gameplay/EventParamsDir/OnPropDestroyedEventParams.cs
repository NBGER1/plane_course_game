using Infrastructure.Events;
using UnityEngine;

namespace Gameplay.EventParamsDir
{
    public class OnPropDestroyedEventParams : EventParams
    {
        #region Fields

        private Vector3 _position;

        #endregion

        #region Constructor

        public OnPropDestroyedEventParams(Vector3 position)
        {
            _position = position;
        }

        #endregion

        #region Properties

        public Vector3 Position => _position;

        #endregion
    }
}