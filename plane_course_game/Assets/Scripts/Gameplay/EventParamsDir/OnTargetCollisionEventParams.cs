
using UnityEngine;

namespace Gameplay.EventParamsDir
{
    public class OnTargetCollisionEventParams
    {
        #region Fields

        private Vector3 _position;
        private int _score;
        #endregion

        #region Constructor

        public OnTargetCollisionEventParams(Vector3 position, int score)
        {
            _position = position;
            _score = score;
        }

        #endregion

        #region Properties

        public Vector3 Position => _position;
        public int Score => _score;

        #endregion
    }
}