using TMPro;
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
        [SerializeField] private float _shotInterval;
        [SerializeField] private float _maxHeight;
        [SerializeField] private float _minHeight;
        [SerializeField] private float _maxSide;
        #endregion


        #region Fields

        private int _ammo;

        #endregion

        #region Properties

        public float MaxHeight => _maxHeight;
        public float MaxSide => _maxSide;
        public float MinHeight => _minHeight;
        public float Speed => _speed;
        public float ShotInterval => _shotInterval;
        public float RotationSpeed => _speed;
        public int MaxAmmo => _maxAmmo;
        public int Ammo => _ammo;

        #endregion
    }
}