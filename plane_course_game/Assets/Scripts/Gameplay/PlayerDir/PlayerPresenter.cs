using System;
using System.Collections;
using System.Numerics;
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

        #endregion

        #region Constructor

        public PlayerPresenter(PlayerModel model, PlayerView view)
        {
            _model = model;
            _view = view;

            SubscribeModelEvents();
            _model.AddAmmo(_model.MaxAmmo);
        }

        #endregion

        #region Methods

        private void SubscribeModelEvents()
        {
            _model.OnZeroAmmo += OnZeroAmmo;
        }

        private void OnZeroAmmo()
        {
            Debug.Log($"Reloading");
            GameplayServices.CoroutineService
                .WaitFor(_model.ReloadTime)
                .OnEnd(() =>
                {
                    _model.AddAmmo(_model.MaxAmmo);
                    Debug.Log($"Gun is ready");
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
            HandleRotation(Vector3.forward,force);
        }

        public void MoveVertical(float force)
        {
            var direction = Vector3.up * force * Time.deltaTime * _model.Speed;
            var position = _view.Transform.position;
            position += direction;
            var constrainedYAxis = Mathf.Clamp(position.y, _model.MinHeight, _model.MaxHeight);
            position = new Vector3(position.x, constrainedYAxis, -6);
            _view.Transform.position = position;
            HandleRotation(Vector3.up,force);
        }

        private void HandleRotation(Vector3 direction,float force)
        {
            Quaternion currentRotation = _view.Transform.rotation;
            Quaternion wantedRotation = Quaternion.Euler(direction * -16.5f * force);
            _view.Transform.rotation =
                Quaternion.RotateTowards(currentRotation, wantedRotation, _model.RotationSpeed * Time.deltaTime);
        }
        public void Fire()
        {
            if (_model.Ammo == 0) return;
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

        #endregion
    }
}