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
        #endregion

        #region Methods

        

        #endregion

        #region Properties

        public AudioSource AudioSource => _audioSource;
        public AudioClip FireSFX => _FireSFX;
        public Animator Animator => _animator;
        public Transform Transform => _transform;
        public Transform LeftFireOutput => _leftFireOutput;
        public Transform RightFireOutput => _rightFireOutput;

        #endregion
    }
}