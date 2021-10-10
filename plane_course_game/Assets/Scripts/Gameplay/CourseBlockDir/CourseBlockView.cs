using System;
using UnityEngine;

namespace Gameplay.CourseBlockDir
{
    public class CourseBlockView : MonoBehaviour
    {
        #region Editor

        [SerializeField] private Transform _transform;
        [SerializeField] private GameObject _gameObject;
        #endregion
        #region Events

        public event Action OnFinish;
        
        #endregion
        #region Methods

        public void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Finish"))
            {
                OnFinish?.Invoke();
            }
        }

        #endregion

        #region Properties

        public Transform Transform => _transform;
        public GameObject GameObject => _gameObject;

        #endregion
    }
}