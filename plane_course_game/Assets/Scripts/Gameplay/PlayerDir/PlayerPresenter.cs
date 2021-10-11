using System;
using System.Collections;
using System.Numerics;
using Gameplay.EventParamsDir;
using Infrastructure.Events;
using Infrastructure.Factories;
using Infrastructure.Services;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

namespace Gameplay.PlayerDir
{
    public class PlayerPresenter
    {
        #region Editor

        private PlayerView _view;
        private PlayerModel _model;

        #endregion

        #region Fields

        private float _maxHeight = 12f;
        private float _minHeight = 6.5f;
        private float _maxLeft = -6;
        private float _maxRight = 6;

        private bool _playerInvulnerable;
        private bool _isActive = false;

        #endregion

        #region Events

        public event Action OnPlayerDisabled;

        #endregion

        #region Constructor

        public PlayerPresenter(PlayerModel model, PlayerView view)
        {
            _model = model;
            _view = view;

            SubscribeViewEvents();
            SubscribeModelEvents();
            _model.AddAmmo(_model.MaxAmmo);
            _model.AddHealth(_model.MaxHealth);
        }

        #endregion

        #region Methods

        private void SubscribeModelEvents()
        {
            _model.OnZeroAmmo += OnZeroAmmo;
            _model.OnAddAmmo += OnAmmoChange;
            _model.OnRemoveAmmo += OnAmmoChange;

            _model.OnZeroHealth += OnZeroHealth;
            _model.OnAddHealth += OnHealthChange;
            _model.OnRemoveHealth += OnRemoveHealth;
        }

        private void SubscribeViewEvents()
        {
            _view.OnCollisionEvent += OnCollisionEvent;
        }

        private void OnCollisionEvent(Collider obj)
        {
            _model.RemoveHealth(_model.OnCollisionDamage);
        }

        private void OnZeroHealth()
        {
            OnPlayerDisabled?.Invoke();
            _view.Animator.SetTrigger(_view.DeathAnimation);
        }

        private void OnRemoveHealth()
        {
            if (_playerInvulnerable) return;
            GameplayServices.CoroutineService
                .WaitFor(_model.InvulnerabilityDuration)
                .OnStart(() =>
                {
                    _playerInvulnerable = true;
                    _view.Animator.SetTrigger(_view.TakeDamageAnimation);
                    OnHealthChange();
                })
                .OnEnd(() => { _playerInvulnerable = false; });
        }

        private void OnAmmoChange()
        {
            var eParams = new OnAmmoChangeEventParams(_model.Ammo);
            GameplayServices.EventBus.Publish(EventTypes.OnPlayerAmmoChange, eParams);
        }

        private void OnHealthChange()
        {
            var eParams = new OnHealthChangeEventParams(_model.Health);
            GameplayServices.EventBus.Publish(EventTypes.OnPlayerHealthChange, eParams);
        }

        private void OnZeroAmmo()
        {
            GameplayServices.EventBus.Publish(EventTypes.OnPlayerReloadingStart, null);
            GameplayServices.CoroutineService
                .WaitFor(_model.ReloadTime)
                .OnEnd(() =>
                {
                    _model.AddAmmo(_model.MaxAmmo);
                    GameplayServices.EventBus.Publish(EventTypes.OnPlayerReloadingEnd, null);
                });
        }

        public void MoveHorizontal(float force)
        {
            var direction = Vector3.right * force * Time.deltaTime * _model.Speed;
            var position = _view.Transform.position;
            position += direction;
            var constrainedXAxis = Mathf.Clamp(position.x, -_model.MaxSide, _model.MaxSide);
            position = new Vector3(constrainedXAxis, position.y, -6);
            _view.Transform.position = position;
            HandleRotation(Vector3.forward, force);
        }

        public void MoveVertical(float force)
        {
            var direction = Vector3.up * force * Time.deltaTime * _model.Speed;
            var position = _view.Transform.position;
            position += direction;
            var constrainedYAxis = Mathf.Clamp(position.y, _model.MinHeight, _model.MaxHeight);
            position = new Vector3(position.x, constrainedYAxis, -6);
            _view.Transform.position = position;
            //      HandleRotation(Vector3.up,force);
        }

        private void HandleRotation(Vector3 direction, float force)
        {
            Quaternion currentRotation = _view.Transform.rotation;
            Quaternion wantedRotation = Quaternion.Euler(direction * -16.5f * force);
            _view.Transform.rotation =
                Quaternion.RotateTowards(currentRotation, wantedRotation, _model.RotationSpeed * Time.deltaTime);
        }

        public void Fire()
        {
            if (_model.Ammo == 0 || _playerInvulnerable) return;
            _model.RemoveAmmo(2);
            GameplayServices.CoroutineService.RunCoroutine(FireGuns());
            if (!_view.AudioSource.isPlaying)
                _view.AudioSource.PlayOneShot(_view.FireSFX);
        }

        IEnumerator FireGuns()
        {
            var projectileLeft = GameplayFactories.Instance.BulletProjectileFactory.Create();
            projectileLeft?.Fire(_view.LeftFireOutput);
            yield return null;
            var projectileRight = GameplayFactories.Instance.BulletProjectileFactory.Create();
            projectileRight?.Fire(_view.RightFireOutput);
        }

        public void SetViewPosition(Vector3 position)
        {
            _view.Transform.position = position;
        }

        #endregion

        #region Properties

        public bool IsActive => _isActive;

        #endregion
    }
}