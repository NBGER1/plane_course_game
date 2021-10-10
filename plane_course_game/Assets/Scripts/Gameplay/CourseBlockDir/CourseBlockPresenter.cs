using System.Collections;
using Gameplay.EventParamsDir;
using Infrastructure.Events;
using Infrastructure.Services;
using UnityEngine;

namespace Gameplay.CourseBlockDir
{
    public class CourseBlockPresenter
    {
        #region Fields

        private CourseBlockModel _model;
        private CourseBlockView _view;
        private float _moveSpeed;
        #endregion

        #region Constructor

        public CourseBlockPresenter(CourseBlockModel model, CourseBlockView view)
        {
            _view = view;
            SubscribeViewEvents();
        }

        #endregion

        #region Methods

        private void SubscribeViewEvents()
        {
            _view.OnFinish += OnViewFinish;
        }

        public void MoveView(float speed)
        {
            _moveSpeed = speed;
            GameplayServices.CoroutineService.RunCoroutine(Move());
        }

        private IEnumerator Move()
        {
            while (true)
            {
                yield return null;
                _view.Transform.position -= Vector3.forward * Time.deltaTime * _moveSpeed;
            }
        }

        private void OnViewFinish()
        {
            var eParams = new OnCourseBlockFinishEventParams(this);
            GameplayServices.EventBus.Publish(EventTypes.OnCourseBlockFinish, eParams);
        }

        public bool IsActiveInHierarchy()
        {
            return _view.GameObject.activeInHierarchy;
        }

        public void SetViewActive()
        {
            _view.GameObject.SetActive(true);
        }

        public void SetPosition(Vector3 position)
        {
            _view.SetRandomRotation();
            _view.Transform.position = position;
        }

        #endregion

        #region Properties

        public Transform ViewTransform => _view.Transform;

        #endregion
    }
}