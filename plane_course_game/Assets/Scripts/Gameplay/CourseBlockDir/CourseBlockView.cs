using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Gameplay.CourseBlockDir
{
    public class CourseBlockView : MonoBehaviour
    {
        #region Editor

        [SerializeField] private Transform _transform;
        [SerializeField] private GameObject _gameObject;
        [SerializeField] private Transform _leftWall;
        [SerializeField] private Transform _rightWall;
        #endregion
        #region Events

        public event Action OnFinish;
        
        #endregion
        
        #region Methods

        private void Start()
        {
            SetRandomRotation();
        }

        public void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Finish"))
            {
                OnFinish?.Invoke();
            }
        }

        public void SetRandomRotation()
        {
            var rndRotLeft = new Vector3(Random.Range(0,120f), Random.Range(0f, 120f), Random.Range(0f, 120f));
            var rndRotRight = new Vector3(Random.Range(0,120f), Random.Range(0f, 120f), Random.Range(0f, 120f));
            _leftWall.Rotate(rndRotLeft);
            _rightWall.Rotate(rndRotRight);
        }
        #endregion

        #region Properties

        public Transform Transform => _transform;
        public GameObject GameObject => _gameObject;

        #endregion
    }
}