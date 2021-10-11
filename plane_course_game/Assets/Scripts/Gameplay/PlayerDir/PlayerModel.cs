using System;
using UnityEngine;

namespace Gameplay.PlayerDir
{
    [CreateAssetMenu(menuName = "Gameplay/Models/Player Model", fileName = "Player Model")]
    public class PlayerModel : ScriptableObject
    {
        #region Editor

        [SerializeField] private float _reloadTime;
        [SerializeField] private float _maxHealth;
        [SerializeField] private float _speed;
        [SerializeField] private float _rotationSpeed;
        [SerializeField] private int _maxAmmo;
        [SerializeField] private float _shotInterval;
        [SerializeField] private float _maxHeight;
        [SerializeField] private float _minHeight;
        [SerializeField] private float _maxSide;
        [SerializeField] private float _onCollisionDamage;
        [SerializeField] private float _invulnerabilityDuration;
        #endregion

        #region Events

        public event Action OnAddAmmo;
        public event Action OnRemoveAmmo;
        public event Action OnAddHealth;
        public event Action OnRemoveHealth;
        public event Action OnZeroHealth;
        public event Action OnZeroAmmo;
        #endregion

        #region Fields

        private int _ammo;
        private float _health;
        #endregion

        #region Methods
        public void AddHealth(float health)
        {
            _health = Mathf.Min(health + _health, _maxHealth);
            OnAddHealth?.Invoke();
        }

        public void RemoveHealth(float health)
        {
            _health = Mathf.Max(_health - health, 0);
            OnRemoveHealth?.Invoke();
            if (_health == 0)
            {
                OnZeroHealth?.Invoke();
            }
        }
        public void AddAmmo(int ammo)
        {
            _ammo = Mathf.Min(ammo + _ammo, _maxAmmo);
            OnAddAmmo?.Invoke();
        }

        public void RemoveAmmo(int ammo)
        {
            _ammo = Mathf.Max(_ammo - ammo, 0);
            OnRemoveAmmo?.Invoke();
            if (_ammo == 0)
            {
                OnZeroAmmo?.Invoke();
            }
        }

        #endregion
        #region Properties

        public float InvulnerabilityDuration => _invulnerabilityDuration;
        public float OnCollisionDamage => _onCollisionDamage;
        public float MaxHealth => _maxHealth;
        public float Health => _health;
        public float ReloadTime => _reloadTime;
        public float MaxHeight => _maxHeight;
        public float MaxSide => _maxSide;
        public float MinHeight => _minHeight;
        public float Speed => _speed;
        public float ShotInterval => _shotInterval;
        public float RotationSpeed => _rotationSpeed;
        public int MaxAmmo => _maxAmmo;
        public int Ammo => _ammo;

        #endregion
    }
}