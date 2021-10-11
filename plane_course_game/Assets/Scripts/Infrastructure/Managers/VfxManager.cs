using System;
using Gameplay;
using Gameplay.EventParamsDir;
using Infrastructure.Abstracts;
using Infrastructure.Events;
using Infrastructure.Services;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Infrastructure.Managers
{
    public class VfxManager : Singleton<VfxManager>
    {
        #region Editor

        [SerializeField] private VfxModel _model;

        #endregion

        #region Fields

        private Transform _cameraTransform;

        #endregion

        #region Methods

        protected override VfxManager GetInstance()
        {
            return this;
        }

        public void Initialize()
        {
            SubscribeEvents();
            _cameraTransform = Camera.main.transform;
        }

        private void SubscribeEvents()
        {
            GameplayServices.EventBus.Subscribe(EventTypes.OnProjectileCollision, OnProjectileCollision);
            GameplayServices.EventBus.Subscribe(EventTypes.OnTargetCollision, OnTargetCollision);
        }

        private void OnTargetCollision(EventParams obj)
        {
            var eParams = obj as OnTargetCollisionEventParams;
            var fx = (GameObject) Instantiate(_model.ProjectileHitVfx, eParams.Position, Quaternion.identity);
            fx.transform.LookAt(_cameraTransform);
        }

        private void OnProjectileCollision(EventParams obj)
        {
            // var eParams = obj as OnProjectileCollisionEventParams;
            //  Instantiate(_model.ProjectileHitVfx, eParams.Position, Quaternion.identity);
        }

        #endregion
    }
}