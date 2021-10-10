using UnityEngine;

namespace Gameplay.PlayerDir
{
    [CreateAssetMenu(menuName = "Gameplay/Models/Player Model", fileName = "Player Model")]
    public class PlayerModel : ScriptableObject
    {
        #region Editor

        [SerializeField] private float _speed;
        [SerializeField] private float _rotationSpeed;
        [SerializeField] private int _maxAmmo;

        #endregion


        #region Fields

        private int _ammo;

        #endregion

        #region Properties

        public float Speed => _speed;
        public float RotationSpeed => _speed;
        public int MaxAmmo => _maxAmmo;
        public int Ammo => _ammo;

        #endregion
    }
}