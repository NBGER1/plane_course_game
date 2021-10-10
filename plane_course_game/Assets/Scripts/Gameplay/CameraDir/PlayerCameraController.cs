using System;
using Gameplay.Core;
using UnityEngine;
using Object = System.Object;

namespace Gameplay.CameraDir
{
    public class PlayerCameraController : IUpdatable
    {
        #region Fields

        private Transform _target;
        private Transform _camera;
        private Vector3 _offset;
        [Range(0.01f,1f)]
        private float _smoothing = 0.5f;
        #endregion

        #region Methods

        public void Initialize(Transform target)
        {
            _camera = Camera.main.transform;
            _target = target;
            _offset = _camera.position - _target.position;
        }

        public void Update()
        {
            if (_target != null)
            {
                Vector3 newPos = _target.position + _offset;
                _camera.position = Vector3.Slerp(_camera.position, newPos, _smoothing);
            }
        }

        public void LateUpdate()
        {
            
        }

        #endregion
    }
}