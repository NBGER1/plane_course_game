using System;
using UnityEngine;

namespace Gameplay.PlayerDir
{
    public class PlayerView : MonoBehaviour
    {
        #region Editor

        [SerializeField] private Animator _animator;
        [SerializeField] private Transform _transform;
        [SerializeField] private Transform _leftFireOutput;
        [SerializeField] private Transform _rightFireOutput;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _FireSFX;
        [SerializeField] private PlayerCollider _collider;

        #endregion

        #region Fields

        private int _takeDamageAnimation = Animator.StringToHash("TakeDamage");
        private int _deathAnimation = Animator.StringToHash("Death");


        #endregion

        #region Events

        public event Action<Collider> OnCollisionEvent;

        #endregion

        #region Methods

        private void Awake()
        {
            _collider.OnCollision += OnCollision;
        }

        private void OnCollision(Collider other)
        {
            OnCollisionEvent?.Invoke(other);
        }

        #endregion

        #region Properties

        public int DeathAnimation => _deathAnimation;
        public int TakeDamageAnimation => _takeDamageAnimation;
        public AudioSource AudioSource => _audioSource;
        public AudioClip FireSFX => _FireSFX;
        public Animator Animator => _animator;
        public Transform Transform => _transform;
        public Transform LeftFireOutput => _leftFireOutput;
        public Transform RightFireOutput => _rightFireOutput;

        #endregion
    }
}