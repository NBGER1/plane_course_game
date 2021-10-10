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
            GameplayServices.CoroutineService.RunCoroutine(Move(speed));
        }

        private IEnumerator Move(float speed)
        {
            while (true)
            {
                yield return null;
                _view.Transform.position -= Vector3.forward * Time.deltaTime * speed;
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

        public void SetViewActive(Vector3 position)
        {
            _view.GameObject.SetActive(true);
            _view.Transform.position = position;
        }

        public void SetPosition(Vector3 position)
        {
            _view.SetRandomRotation();
            _view.Transform.position = position;
        }

        #endregion
    }
}