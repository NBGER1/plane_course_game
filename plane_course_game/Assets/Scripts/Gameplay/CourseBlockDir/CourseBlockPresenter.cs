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
        }

        #endregion

        #region Methods

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
            _view.Transform.position = position;
        }

        #endregion
    }
}