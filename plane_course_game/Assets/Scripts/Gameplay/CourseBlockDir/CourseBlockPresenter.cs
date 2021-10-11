using System.Collections;
using Gameplay.CourseTargetDir;
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
        private CourseTargetPresenter _targetPresenter;
        private float _moveSpeed;

        #endregion

        #region Constructor

        public CourseBlockPresenter(CourseBlockModel model, CourseBlockView view)
        {
            _view = view;
            _model = model;
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

        public void SetTarget(CourseTargetPresenter target)
        {
            _targetPresenter = target;
            SetTargetPositionAndEnable();
        }

        private void SetTargetPositionAndEnable()
        {
            if (_targetPresenter == null) return;
            var chance = Random.Range(0f, 1f);
            if (chance <= _model.TargetAppearanceChance)
            {
                _targetPresenter.ViewTransform.SetParent(_view.Transform);
                var randomPos = new Vector3(Random.Range(-10, 10), Random.Range(3, 13), 0);
                _targetPresenter.ViewTransform.position = _view.Transform.position + randomPos;
                _targetPresenter.SetViewActive();
            }
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
            SetTargetPositionAndEnable();
            _view.Transform.position = position;
        }

        #endregion

        #region Properties

        public Transform ViewTransform => _view.Transform;

        #endregion
    }
}