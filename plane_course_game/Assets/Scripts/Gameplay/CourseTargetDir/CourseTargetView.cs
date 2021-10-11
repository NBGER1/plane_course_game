using System;
using Gameplay.EventParamsDir;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Gameplay.CourseTargetDir
{
    public class CourseTargetView : MonoBehaviour
    {
        #region Editor

        [SerializeField] private Transform _transform;
        [SerializeField] private GameObject _gameObject;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _onHitSFX;
        [SerializeField] private CourseTargetTrigger _collider;
        [SerializeField] private GameObject _VFXObject;
        #endregion

        #region Events

        public event Action<Collider> OnTriggerEnterEvent;

        #endregion
        #region Methods

        private void Awake()
        {
            _collider.OnCollision += OnCollision;
        }

        private void OnCollision(Collider other)
        {
            OnTriggerEnterEvent?.Invoke(other);

        }

        #endregion
        #region Properties

        public GameObject VFXObject => _VFXObject;
        public Transform Transform => _transform;
        public GameObject GameObject => _gameObject;
        public AudioSource AudioSource => _audioSource;
        public AudioClip OnHitSFX => _onHitSFX;

        #endregion
    }
}