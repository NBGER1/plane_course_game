using System.Collections.Generic;
using Gameplay.CourseTargetDir;
using Gameplay.ProjectilesDir;
using UnityEngine;

namespace Gameplay.FactoriesDir
{
    public abstract class CourseTargetFactoryBase : MonoBehaviour
    {
        #region Fields

        [SerializeField] protected float _poolSize;
        [SerializeField] protected Object _view;
        [SerializeField] protected CourseTargetModel _model;
        protected CourseTargetPresenter[] _presenters;

        #endregion

        #region Methods

        protected virtual void Initialize()
        {
            var pool = new GameObject("TargetsPool");
            List<CourseTargetPresenter> presenterList = new List<CourseTargetPresenter>();
            for (var i = 0; i < _poolSize; i++)
            {
                var view = Instantiate(_view, pool.transform) as GameObject;
                var model = Instantiate(_model);
                var presenter = new CourseTargetPresenter(model, view.GetComponent<CourseTargetView>());
                presenterList.Add(presenter);
                view.SetActive(false);
            }

            _presenters = presenterList.ToArray();
        }

        private void Awake()
        {
            Initialize();
        }

        public virtual CourseTargetPresenter Create()
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