using System.Collections;
using Gameplay.SharedInterfaces;
using Infrastructure.Services;
using UnityEngine;

namespace Gameplay.ProjectilesDir
{
    public class ProjectilePresenter
    {
        #region Fields

        private ProjectileModel _model;
        private ProjectileView _view;

        private Vector3 _origin;

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
            other.GetComponent<IDamageable>()?.TakeDamage(_model.Damage);
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

        public void Fire(Vector3 position)
        {
            _origin = position;
            SetViewActive();
            _view.Transform.position = position;
            MoveView();
        }

        private void MoveView()
        {
            GameplayServices.CoroutineService.RunCoroutine(Move());
        }

        private IEnumerator Move()
        {
            while (Vector3.Distance(_origin, _view.Transform.position) < _model.MaxDistance)
            {
                yield return null;
                _view.Transform.position += Vector3.forward * Time.deltaTime * _model.Speed;
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