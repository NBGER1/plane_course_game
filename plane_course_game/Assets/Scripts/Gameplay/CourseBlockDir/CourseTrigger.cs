using System;
using UnityEngine;

namespace Gameplay.CourseBlockDir
{
    public class CourseTrigger : MonoBehaviour
    {
        #region Editor

        [SerializeField] private CourseBlockView _view;

        #endregion

        #region Events

        public event Action OnFinishCollision;


        #endregion
        #region Methods

        public void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Finish"))
            {
                OnFinishCollision?.Invoke();
            }
        }

        #endregion
    }

}