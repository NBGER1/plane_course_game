using System.Collections;
using Gameplay.EventParamsDir;
using Gameplay.SharedInterfaces;
using Infrastructure.Events;
using Infrastructure.Services;
using UnityEngine;

namespace Gameplay.ProjectilesDir
{
    public class ProjectilePresenter
    {
        #region Fields

        private ProjectileModel _model;
        private ProjectileView _view;

        private Transform _origin;
        

        #endregion

        #region Constructor

        public ProjectilePresenter(ProjectileModel model, ProjectileView view)
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
            other.gameObject.GetComponent<IDamageable>()?.TakeDamage(_model.Damage);
            var position = _view.Transform.position;
            Debug.Log("Collided with " + other.transform.name);
            var eParams = new OnProjectileCollisionEventParams(position);
            GameplayServices.EventBus.Publish(EventTypes.OnProjectileCollision,eParams);
            SetViewInactive();
        }

        public void SetViewActive()
        {
            _view.GameObject.SetActive(true);
        }

        public void SetViewInactive()
        {
            _view.GameObject.SetActive(false);
        }

        public void Fire(Transform transform)
        {
            _origin = transform;
            SetViewActive();
            _view.Transform.position = transform.position;
            _view.Transform.forward = transform.forward;
            MoveView();
        }

        private void MoveView()
        {
            GameplayServices.CoroutineService.RunCoroutine(Move());
        }

        private IEnumerator Move()
        {
            while (Vector3.Distance(_origin.position, _view.Transform.position) < _model.MaxDistance)
            {
                yield return null;
                _view.Transform.position += _view.Transform.forward * Time.deltaTime * _model.Speed;
            }

            SetViewInactive();
        }

        public bool IsActiveInHierarchy()
        {
            return _view.GameObject.activeInHierarchy;
        }

        #endregion
    }
}