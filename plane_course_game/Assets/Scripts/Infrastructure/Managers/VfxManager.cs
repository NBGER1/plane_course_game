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
            GameplayServices.EventBus.Subscribe(EventTypes.OnBarrelDestroyed, OnBarrelDestroyed);
            GameplayServices.EventBus.Subscribe(EventTypes.OnCollectibleCollect, OnCollectibleCollect);
        }

        private void OnCollectibleCollect(EventParams obj)
        {
            var eParams = obj as OnCollectibleCollectEventParams;
            var fx = (GameObject) Instantiate(_model.GoldCollectibleVfx, eParams.Position, Quaternion.identity);
            fx.transform.LookAt(_cameraTransform);
        }

        private void OnBarrelDestroyed(EventParams obj)
        {
            var eParams = obj as OnPropDestroyedEventParams;
            var fx = (GameObject)Instantiate(_model.BarrelDestroyedVfx, eParams.Position, Quaternion.identity);
            fx.transform.LookAt(_cameraTransform);
        }

        #endregion
    }
}