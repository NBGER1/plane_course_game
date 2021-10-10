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
        }

        #endregion

        #region Methods

        public void MoveHorizontal(float force)
        {
            _view.Transform.position += Vector3.right * force * Time.deltaTime * _model.Speed;
            Quaternion currentRotation = _view.Transform.rotation;
            Quaternion wantedRotation = Quaternion.Euler(Vector3.forward * -45f * force);
            _view.Transform.rotation =
                Quaternion.RotateTowards(currentRotation, wantedRotation, _model.RotationSpeed * Time.deltaTime);
        }

        public void MoveVertical(float force)
        {
            _view.Transform.position += Vector3.up * force * Time.deltaTime * _model.Speed;
            Quaternion currentRotation = _view.Transform.rotation;
            Quaternion wantedRotation = Quaternion.Euler(Vector3.up * -45f * force);
            _view.Transform.rotation =
                Quaternion.RotateTowards(currentRotation, wantedRotation, _model.RotationSpeed * Time.deltaTime);
        }

        public void Fire()
        {
            GameplayServices.CoroutineService.RunCoroutine(FireGuns());
            if (!_view.AudioSource.isPlaying)
                _view.AudioSource.PlayOneShot(_view.FireSFX);
        }

        IEnumerator FireGuns()
        {
            var projectileLeft = GameplayFactories.Instance.BulletProjectileFactory.Create();
            projectileLeft?.Fire(_view.LeftFireOutput.position);
            yield return null;
            var projectileRight = GameplayFactories.Instance.BulletProjectileFactory.Create();
            projectileRight?.Fire(_view.RightFireOutput.position);
        }

        #endregion
    }
}