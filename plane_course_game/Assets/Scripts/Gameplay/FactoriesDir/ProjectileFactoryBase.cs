using System.Collections.Generic;
using Gameplay.CourseBlockDir;
using Gameplay.ProjectilesDir;
using UnityEngine;

namespace Gameplay.FactoriesDir
{
    public abstract class ProjectileFactoryBase : MonoBehaviour
    {
        #region Fields

        [SerializeField] protected float _poolSize;
        [SerializeField] protected Object _view;
        [SerializeField] protected ProjectileModel _model;
        protected ProjectilePresenter[] _presenters;

        #endregion

        #region Methods

        protected virtual void Initialize()
        {
            var pool = new GameObject("ProjectilePool");
            List<ProjectilePresenter> presenterList = new List<ProjectilePresenter>();
            for (var i = 0; i < _poolSize; i++)
            {
                var view = Instantiate(_view,pool.transform) as GameObject;
                var model = Instantiate(_model);
                var presenter = new ProjectilePresenter(model, view.GetComponent<ProjectileView>());
                presenterList.Add(presenter);
                view.SetActive(false);
            }

            _presenters = presenterList.ToArray();
        }

        private void Awake()
        {
            Initialize();
        }

        public virtual ProjectilePresenter Create()
        {
            foreach (var presenter in _presenters)
            {
                if (!presenter.IsActiveInHierarchy()) return presenter;
            }

            return null;
        }

        #endregion
    }
}