using Gameplay.CourseBlockDir;
using Infrastructure.Events;

namespace Gameplay.EventParamsDir 
{
    public class OnCourseBlockFinishEventParams : EventParams
    {
        #region Fields

        private CourseBlockPresenter _courseBlockPresenter;

        #endregion

        #region Constructor

        public OnCourseBlockFinishEventParams(CourseBlockPresenter courseBlockPresenter)
        {
            _courseBlockPresenter = courseBlockPresenter;
        }
        

        #endregion

        #region Properties

        public CourseBlockPresenter CourseBlockPresenter => _courseBlockPresenter;

        #endregion
    }
}