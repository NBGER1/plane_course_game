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
        [SerializeField] private Transform[] _rotatingObjects;
        [SerializeField] private Transform[] _rotatingSideways;
        [SerializeField] private Transform[] _randomScaleWidth;
        [SerializeField] private CourseTrigger _courseTrigger;

        #endregion

        #region Events

        public event Action OnFinish;

        #endregion

        #region Methods

        private void Start()
        {
            SetRandomRotation();
            _courseTrigger.OnFinishCollision += OnFinishCollision;
        }

        private void OnFinishCollision()
        {
            OnFinish?.Invoke();
        }


        public void SetRandomRotation()
        {
            foreach (var obj in _rotatingObjects)
            {
                obj.Rotate(new Vector3(Random.Range(0, 120f), Random.Range(0f, 120f), Random.Range(0f, 120f)));
            }

            foreach (var obj in _rotatingSideways)
            {
                obj.Rotate(new Vector3(0f, 0f, Random.Range(0f, 120f)));
            }
            foreach (var obj in _randomScaleWidth)
            {
                obj.localScale = new Vector3(Random.Range(25, 200), 200, Random.Range(25, 200));
            }
        }

        #endregion

        #region Properties

        public Transform Transform => _transform;
        public GameObject GameObject => _gameObject;

        #endregion
    }
}