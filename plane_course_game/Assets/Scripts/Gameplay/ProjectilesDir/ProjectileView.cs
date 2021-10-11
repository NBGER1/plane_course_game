using System;
using UnityEngine;

namespace Gameplay.ProjectilesDir
{
    public class ProjectileView:MonoBehaviour
    {
        #region Editor

        [SerializeField] private Transform _transform;
        [SerializeField] private GameObject _gameObject;
        
        #endregion

        #region Events

        public event Action<Collider> OnTriggerEnterEvent;

        #endregion
        #region Methods


        private void OnTriggerEnter(Collider other)
        {
           OnTriggerEnterEvent?.Invoke(other);
        }

        #endregion
        #region Properties

        public Transform Transform => _transform;
        public GameObject GameObject => _gameObject;

        #endregion
    }
}