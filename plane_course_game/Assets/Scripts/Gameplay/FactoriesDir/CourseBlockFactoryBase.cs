using System;
using System.Collections.Generic;
using Gameplay.CourseBlockDir;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Gameplay.FactoriesDir
{
    public abstract class CourseBlockFactoryBase : MonoBehaviour
    {
        #region Fields

        [SerializeField] protected int _poolSize;
        [SerializeField] protected Object _view;
        [SerializeField] protected CourseBlockModel _model;
        protected CourseBlockPresenter[] _presenters;

        #endregion

        #region Methods

        protected virtual void Initialize()
        {
            List<CourseBlockPresenter> presenterList = new List<CourseBlockPresenter>();
            for (var i = 0; i < _poolSize; i++)
            {
                var view = Instantiate(_view) as GameObject;
                var model = Instantiate(_model);
                var presenter = new CourseBlockPresenter(model, view.GetComponent<CourseBlockView>());
                presenterList.Add(presenter);
                view.SetActive(false);
            }

            _presenters = presenterList.ToArray();
        }

        private void Awake()
        {
            Initialize();
        }

        public virtual CourseBlockPresenter Create()
        {
            foreach (var presenter in _presenters)
            {
                if (!presenter.IsActiveInHierarchy()) return presenter;
            }

            return null;
        }

        #endregion

        #region Properties

        public int PoolSize => _poolSize;

        #endregion
    }
}