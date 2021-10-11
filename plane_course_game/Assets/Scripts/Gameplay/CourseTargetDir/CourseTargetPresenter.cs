using System.Collections;
using Gameplay.EventParamsDir;
using Gameplay.SharedInterfaces;
using Infrastructure.Events;
using Infrastructure.Services;
using UnityEngine;

namespace Gameplay.CourseTargetDir
{
    public class CourseTargetPresenter
    {
        #region Fields

        private CourseTargetModel _model;
        private CourseTargetView _view;

        private Transform _origin;
        private bool _isHit;
        private float _inactiveDelay = 0.3f;

        #endregion

        #region Constructor

        public CourseTargetPresenter(CourseTargetModel model, CourseTargetView view)
        {
            _view = view;
            _model = model;
            SubscribeViewEvents();
        }

        #endregion

        #region Methods

        private void SubscribeViewEvents()
        {
            _view.OnTriggerEnterEvent += OnTriggerEnterEvent;
        }

        private void OnTriggerEnterEvent(Collider other)
        {
            if (_isHit) return;
            _isHit = true;
            _view.VFXObject.SetActive(false);
            GameplayServices.CoroutineService.RunCoroutine(PlaySFXAndSetInactive());
            //   var position = _view.Transform.position;
            //  var eParams = new OnProjectileCollisionEventParams(position);
            //  GameplayServices.EventBus.Publish(EventTypes.OnProjectileCollision, eParams);
        }

        IEnumerator PlaySFXAndSetInactive()
        {
            _view.AudioSource.clip = _view.OnHitSFX;
            _view.AudioSource.Play();
            yield return new WaitForSeconds(_view.AudioSource.clip.length);
            SetViewInactive();
        }

        public void SetViewActive()
        {
            _view.GameObject.SetActive(true);
            _view.VFXObject.SetActive(true);
        }

        public void SetViewInactive()
        {
            _view.GameObject.SetActive(false);
        }

        public bool IsActiveInHierarchy()
        {
            return _view.GameObject.activeInHierarchy;
        }

        #endregion

        #region Properties

        public Transform ViewTransform => _view.Transform;

        #endregion
    }
}