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
        }

 

        #endregion
    }
}